namespace SteamworksDumper;

using System.Runtime.InteropServices;

using Elf32_Half = ushort;
using Elf32_Word = uint;
using Elf32_Sword = int;

using Elf32_Off = uint;
using Elf32_Addr = uint;

// ReSharper disable InconsistentNaming

[StructLayout(LayoutKind.Sequential)]
public struct Elf32_Sym
{
    public Elf32_Word st_name;
    public Elf32_Addr st_value;
    public Elf32_Word st_size;
    public byte st_info;
    public byte st_other;
    public Elf32_Half st_shndx;
};

[StructLayout(LayoutKind.Sequential)]
public struct Elf32_Rel
{
    public Elf32_Addr r_offset;
    public Elf32_Word r_info;
};

public enum BindType : byte
{
    STB_LOCAL,
    STB_GLOBAL,
    STB_WEAK,
    STB_LOOS = 10,
    STB_HIOS = 12,
    STB_LOPROC = 13,
    STB_HIPROC = 14
}

public enum RelocType : byte
{
    R_386_NONE,
    R_386_32, 
    R_386_PC32,
    R_386_GOT32,
    R_386_PLT32,
    R_386_COPY,
    R_386_GLOB_DAT,
    R_386_JMP_SLOT,
    R_386_RELATIVE,
    R_386_GOTOFF,
    R_386_GOTPC,
    R_386_32PLT,
    R_386_16 = 20,
    R_386_PC16,
    R_386_8,
    R_386_PC8,
    R_386_SIZE32 = 38
}

public static class ELFUtils
{
    public static BindType ELF32_ST_BIND(byte info)
        => (BindType)(byte)(info >> 4);
    
    public static RelocType ELF32_R_TYPE(uint info)
        => (RelocType)(byte)info;
    
    public static uint ELF32_R_SYM(uint info)
        => info >> 8;
}