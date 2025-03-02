using ELFSharp;
using ELFSharp.ELF;
using ELFSharp.ELF.Segments;
using Rosentti.Capstone;
using Rosentti.Capstone.Native;
using Rosentti.Capstone.X86;
using SteamworksDumper.Extensions;
using SteamworksDumper.Interface;
using SteamworksDumper.Utils;

namespace SteamworksDumper.LinuxX86;

public partial class LinuxX86Dumper : IDumper
{
    private readonly ELF<uint> elf;
    private readonly CapstoneX86Disassembler disassembler;
    private readonly byte[] programImage;
    private readonly LinuxX86Constants constants;
    private Dictionary<long, List<long>> m_extRefs = new();
    private readonly Dictionary<int, int> functionLengths = new();
    
    /// <summary>
    /// Offsets to consts
    /// </summary>
    private readonly List<int> consts = new();

    /// <summary>
    /// Offset of .got section
    /// </summary>
    private readonly int gotOffset;

    private bool enableDevOnlyConstantCaching;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="enableDevOnlyConstantCaching">Enables caching constants to /tmp/cachedconsts.bin. If not running in development where the same executable is present each run, this should be set to false.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public LinuxX86Dumper(Stream stream, bool enableDevOnlyConstantCaching = false)
    {
        this.enableDevOnlyConstantCaching = enableDevOnlyConstantCaching;
        
        elf = ELFReader.Load<uint>(stream, true);
        Console.WriteLine($"ELF information: [Machine: {elf.Machine}, Class: {elf.Class}, Endianness: {elf.Endianess}, Type: {elf.Type}]");
        
        if (elf.Type != FileType.SharedObject)
            Console.WriteLine("WARNING: Not a shared library!");
        
        if (elf.Endianess != Endianess.LittleEndian)
            Console.WriteLine("WARNING: Not little endian!");

        if (elf.Class != Class.Bit32)
            Console.WriteLine("WARNING: Not 32-bit!");

        var mode = elf.Class switch
        {
            Class.Bit32 => cs_mode.CS_MODE_32,
            Class.Bit64 => cs_mode.CS_MODE_64,
            _ => throw new ArgumentOutOfRangeException(nameof(elf.Class))
        };

        if (elf.Endianess == Endianess.BigEndian)
            mode += (uint)cs_mode.CS_MODE_BIG_ENDIAN;
        
        this.disassembler = CapstoneDisassembler.CreateX86Disassembler(mode); 
        
        disassembler.EnableInstructionDetails = true;
        disassembler.EnableSkipDataMode = true;
        
        // Construct a module image from the sections to the segments (loadable sections, some sections don't become segments and are only used for linking, etc.)   
        programImage = CreateImage();
        
        this.GetSectionInfo(".text", out _, out var textOffset);
        Console.WriteLine("Text offset: " + GhidraUtil.GetOffsetForGhidra(textOffset));
        
        this.GetSectionInfo(".got", out _, out gotOffset);
        Console.WriteLine(".got offset: " + GhidraUtil.GetOffsetForGhidra(gotOffset));
        
        ProcessDynSymtab();
        ProcessRelocations();
        
        this.constants = new LinuxX86Constants(this);
        
        ReadExceptionTablesForFunctionLengths();
        
        FindConsts();
        
        FindExtSymRefs();
        //UpdatePltSymbols();
    }
    
    private byte[] CreateImage()
    {
        int imageSize = 0;
        
        foreach (var segment in elf.Segments)
        {
            if (segment.Type != SegmentType.Load)
                continue;

            var memReq = segment.Address + segment.Size;
            if (memReq > imageSize)
                imageSize = (int)memReq;
        }

        using var stream = new MemoryStream(imageSize);
        
        foreach (var segment in elf.Segments)
        {
            if (segment.Type != SegmentType.Load)
                continue;

            stream.Position = segment.Address;
            stream.Write(segment.GetMemoryContents());
        }

        return stream.ToArray();
    }
    
    public long FindSignature(string name, bool required, string sign, string mask)
    {
        this.GetSectionInfo(".text", out _, out var startOffset);
        return SigScanner.FindSignatureHelper(this.GetSection(".text"), startOffset, name, required, sign, mask);
    }

    public bool TryGetSectionInfo(string sectionName, out int endAddr, out int startAddr)
    {
        if (!elf.TryGetSection(sectionName, out var sect))
        {
            endAddr = 0;
            startAddr = 0;
            return false;
        }
        
        startAddr = (int)sect.LoadAddress;
        endAddr = (int)(startAddr + sect.Size);
        return true;
    }

    public bool TryGetSection(string sectionName, out Span<byte> section)
    {
        if (!TryGetSectionInfo(sectionName, out var endAddr, out var startAddr))
        {
            section = [];
            return false;
        }
        
        section = programImage.AsSpan()[startAddr..endAddr];
        return true;
    }
    
    private static readonly string[] dataSections = [".data", ".rodata", ".data.rel.ro", ".data.rel.ro.local", ".rodata.str", ".rodata.cst"];

    private readonly List<(int, int)> dataOffsets = new();
    private void PrepareDataOffsets()
    {
        if (dataOffsets.Count != 0)
            return;
        
        for (int i = 0; i < dataSections.Length; i++)
        {
            if (!TryGetSectionInfo(dataSections[i], out int dataEndAddr, out int dataOffset))
                continue;
            
            dataOffsets.Add((dataEndAddr, dataOffset));
        }
    }
    
    public bool IsOffsetInData(int offset)
    {
        PrepareDataOffsets();
        
        for (int i = 0; i < dataOffsets.Count; i++)
        {
            if (offset < dataOffsets[i].Item1 && offset >= dataOffsets[i].Item2)
                return true;
        }

        return false;
    }
    
    private static readonly string[] textSections = [".text"];
    public bool IsOffsetInText(int offset)
    {
        for (int i = 0; i < textSections.Length; i++)
        {
            if (!TryGetSectionInfo(textSections[i], out int textEndAddr, out int textOffset))
                continue;

            if (offset < textEndAddr && offset >= textOffset)
                return true;
        }

        return false;
    }
    
    public IEnumerable<long> GetRefsToSymbol(long value)
    {
        if (!m_extRefs.TryGetValue(value, out var refs))
            return [];

        return refs;
    }

    private readonly Dictionary<string, long> importRelocsCache = new();
    public long GetImportRelocByName(string name)
    {
        if (importRelocsCache.TryGetValue(name, out var address))
        {
            return address;
        }
        
        var dynsymSect = this.GetSection(".dynsym").As<byte, Elf32_Sym>();
        var dynstrSection = this.GetSection(".dynstr");
        for (int i = 0; i < dynsymSect.Length; i++)
        {
            int startAddr = (int)dynsymSect[i].st_name;
            if (startAddr == 0)
                continue;
            
            var s = dynstrSection[startAddr..].ReadString();
            if (s == name)
            {
                return importRelocsCache[name] = dynsymSect[i].st_value;
            }
        }

        return -1;
    }

    public void Dispose()
    {
        elf.Dispose();
        disassembler.Dispose();
    }
}