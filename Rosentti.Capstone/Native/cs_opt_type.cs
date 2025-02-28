namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum cs_opt_type : uint
{
    CS_OPT_INVALID = 0,
    CS_OPT_SYNTAX,
    CS_OPT_DETAIL,
    CS_OPT_MODE,
    CS_OPT_MEM,
    CS_OPT_SKIPDATA,
    CS_OPT_SKIPDATA_SETUP,
    CS_OPT_MNEMONIC,
    CS_OPT_UNSIGNED,
    CS_OPT_NO_BRANCH_OFFSET,
}
