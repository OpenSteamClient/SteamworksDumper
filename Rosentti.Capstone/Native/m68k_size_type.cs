namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_size_type : uint
{
    M68K_SIZE_TYPE_INVALID = 0,
    M68K_SIZE_TYPE_CPU,
    M68K_SIZE_TYPE_FPU,
}
