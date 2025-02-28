namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_group_type : uint
{
    M68K_GRP_INVALID = 0,
    M68K_GRP_JUMP,
    M68K_GRP_RET = 3,
    M68K_GRP_IRET = 5,
    M68K_GRP_BRANCH_RELATIVE = 7,
    M68K_GRP_ENDING,
}
