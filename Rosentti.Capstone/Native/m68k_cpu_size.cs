namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_cpu_size : uint
{
    M68K_CPU_SIZE_NONE = 0,
    M68K_CPU_SIZE_BYTE = 1,
    M68K_CPU_SIZE_WORD = 2,
    M68K_CPU_SIZE_LONG = 4,
}
