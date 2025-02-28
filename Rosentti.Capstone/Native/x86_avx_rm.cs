namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum x86_avx_rm : uint
{
    X86_AVX_RM_INVALID = 0,
    X86_AVX_RM_RN,
    X86_AVX_RM_RD,
    X86_AVX_RM_RU,
    X86_AVX_RM_RZ,
}
