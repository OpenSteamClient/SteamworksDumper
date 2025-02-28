namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_fpu_size : uint
{
    M68K_FPU_SIZE_NONE = 0,
    M68K_FPU_SIZE_SINGLE = 4,
    M68K_FPU_SIZE_DOUBLE = 8,
    M68K_FPU_SIZE_EXTENDED = 12,
}
