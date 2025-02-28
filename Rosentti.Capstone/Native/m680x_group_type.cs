namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m680x_group_type : uint
{
    M680X_GRP_INVALID = 0,
    M680X_GRP_JUMP,
    M680X_GRP_CALL,
    M680X_GRP_RET,
    M680X_GRP_INT,
    M680X_GRP_IRET,
    M680X_GRP_PRIV,
    M680X_GRP_BRAREL,
    M680X_GRP_ENDING,
}
