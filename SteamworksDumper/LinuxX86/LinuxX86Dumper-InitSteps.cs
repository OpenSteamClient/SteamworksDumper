using System.Diagnostics;
using System.Runtime.InteropServices;
using Rosentti.Capstone;
using Rosentti.Capstone.Native;
using Rosentti.Capstone.X86;
using SteamworksDumper.Extensions;
using SteamworksDumper.Utils;

namespace SteamworksDumper.LinuxX86;

public partial class LinuxX86Dumper
{
    /// <summary>
    /// Populate .dynsym section with fake "external" addresses for referencing purposes
    /// </summary>
    private void ProcessDynSymtab()
    {
        var externalAddress = programImage.Length + 4096;
        var symbols = this.GetSection(".dynsym").As<byte, Elf32_Sym>();
        
        for (int i = 0; i < symbols.Length; i++)
        {
            if (symbols[i].st_value == 0 &&
                ELFUtils.ELF32_ST_BIND(symbols[i].st_info) is BindType.STB_GLOBAL or BindType.STB_WEAK)
            {
                symbols[i].st_value = (uint)externalAddress;
                externalAddress += 4;
            }
        }
        
        Console.WriteLine($"Processed .dynsym with {symbols.Length} entries");
    }
    
    private void ProcessRelocations()
    {
        var relocs = this.GetSection(".rel.dyn").As<byte, Elf32_Rel>();
        var symtab = this.GetSection(".dynsym").As<byte, Elf32_Sym>();
        var pltRelocs = this.GetSection(".rel.plt").As<byte, Elf32_Rel>();

        for (int i = 0; i < relocs.Length; i++)
        {
            if (ELFUtils.ELF32_R_TYPE(relocs[i].r_info) != RelocType.R_386_32)
                continue;

            WriteToImage((int)relocs[i].r_offset, symtab[(int)ELFUtils.ELF32_R_SYM(relocs[i].r_info)].st_value);
        }

        for (int i = 0; i < pltRelocs.Length; i++)
        {
            if (ELFUtils.ELF32_R_TYPE(pltRelocs[i].r_info) != RelocType.R_386_JMP_SLOT)
                continue;
            
            WriteToImage((int)pltRelocs[i].r_offset, symtab[(int)ELFUtils.ELF32_R_SYM(pltRelocs[i].r_info)].st_value);
        }
    }
    
    private void WriteToImage<T>(int offset, in T value) where T : unmanaged
    {
        MemoryMarshal.Write(programImage.AsSpan().Slice(offset), in value);
    }
    
    private void FindConsts()
    {
        if (enableDevOnlyConstantCaching && File.Exists("/tmp/cachedconsts.bin"))
        {
            Console.WriteLine("Using cached constants");
            
            using var stream = new MemoryStream(File.ReadAllBytes("/tmp/cachedconsts.bin"));
            using var reader = new BinaryReader(stream);
            int num = reader.ReadInt32();
            Console.WriteLine($"{num} cached constants");
            
            consts.Capacity = num;
            while (num > 0)
            {
                consts.Add(reader.ReadInt32());
                num--;
            }
            
            return;
        }
        
        //TODO: Could this be optimized in debug builds? DPA also reports 3 gigabytes of allocations here...
        Stopwatch measure = new();
        measure.Start();
        
        Console.WriteLine("Discovering constants (this will take a while)");
        this.GetSectionInfo(".got", out _, out var gotOffset);
        
        using var detaillessDisassembler = CapstoneDisassembler.CreateX86Disassembler(disassembler.Mode);
        detaillessDisassembler.EnableInstructionDetails = false;
        detaillessDisassembler.EnableSkipDataMode = true;

        using var results = detaillessDisassembler.Disassemble(this.GetSection(".text"), 0);
        using var iteratingDisassembler = disassembler.CreateIteratingDisassembler();
        
        foreach (var liteInstr in results.Instructions)
        {
            if (liteInstr.Id == x86_insn.X86_INS_MOV || liteInstr.Id == x86_insn.X86_INS_LEA ||
                liteInstr.Id == x86_insn.X86_INS_CMP)
            {
                UIntPtr instrOffset = 0;
                
                if (!iteratingDisassembler.Iterate(liteInstr.Bytes, ref instrOffset))
                    throw new Exception("Failed to disassemble instruction we previously disassembled?");
                
                foreach (var operand in iteratingDisassembler.CurrentInstruction.Details.Operands)
                {
                    if (operand.Type == x86_op_type.X86_OP_MEM && operand.Memory.@base != x86_reg.X86_REG_INVALID)
                    {
                        var offset = gotOffset + (int)operand.Memory.disp;
                        if (IsOffsetInData(offset))
                        {
                            consts.Add(offset);
                        }
                    }
                }
            }
        }

        if (consts.Count < 256)
            throw new Exception("Did not find enough constants. Pls fix.");
        
        Console.WriteLine($"Found {consts.Count} constants in {measure.Elapsed.TotalSeconds}s");
        if (enableDevOnlyConstantCaching) {
            using var stream = new MemoryStream(4 + consts.Count * 4);
            using var writer = new BinaryWriter(stream);
            writer.Write(consts.Count);
            foreach (var c in consts)
            {
                writer.Write(c);
            }
            
            File.WriteAllBytes("/tmp/cachedconsts.bin", stream.ToArray());
        }
    }
    
    private void ReadExceptionTablesForFunctionLengths()
    {
        this.GetSectionInfo(".eh_frame", out _, out var startAddr);
        using var stream = new MemoryStream(this.GetSection(".eh_frame").ToArray());
        using var reader = new BinaryReader(stream);
        
        while (true)
        {
            ulong length = reader.ReadUInt32();
            if (length == 0)
                return;
            
            if (length == 0xffffffff)
                length = reader.ReadUInt64();
        
            if (reader.ReadUInt32() == 0)
            {
                // This is a CIE entry, skip.
                // -4, since we read the type above
                stream.Seek((long)length - 4, SeekOrigin.Current);
                continue;
            }
            
            // Assuming DW_EH_PE_sdata4 | DW_EH_PE_pcrel (with a -8, for some reason?)
            uint pcBegin = reader.ReadUInt32();
            uint pcRange = reader.ReadUInt32();

            checked
            {
                functionLengths[(int)(startAddr + stream.Position + pcBegin) - 8] = (int)pcRange;
            }

            // 32-bit platform, encoded = 32-bit ptr
            const int sizeofEncoded = 4;
            
            // PcBegin + PcRange fields + read at "if (reader.ReadUInt32() == 0)"
            stream.Seek((long)length - (sizeofEncoded * 2) - sizeof(UInt32), SeekOrigin.Current);
        }
    }

    private void FindExtSymRefs()
    {
        var dynsym = this.GetSection(".dynsym").As<byte, Elf32_Sym>();
        var relocs = this.GetSection(".rel.dyn").As<byte, Elf32_Rel>();
        
        for (int i = 0; i < relocs.Length; i++)
        {
            if (ELFUtils.ELF32_R_TYPE(relocs[i].r_info) != RelocType.R_386_32)
                continue;

            var val = dynsym[(int)ELFUtils.ELF32_R_SYM(relocs[i].r_info)].st_value;
            if (!m_extRefs.ContainsKey(val))
                m_extRefs[val] = new();
            
            m_extRefs[val].Add(relocs[i].r_offset);
        }
    }
}