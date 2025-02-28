namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum cs_err : uint
{
    CS_ERR_OK = 0,
    CS_ERR_MEM,
    CS_ERR_ARCH,
    CS_ERR_HANDLE,
    CS_ERR_CSH,
    CS_ERR_MODE,
    CS_ERR_OPTION,
    CS_ERR_DETAIL,
    CS_ERR_MEMSETUP,
    CS_ERR_VERSION,
    CS_ERR_DIET,
    CS_ERR_SKIPDATA,
    CS_ERR_X86_ATT,
    CS_ERR_X86_INTEL,
    CS_ERR_X86_MASM,
}
