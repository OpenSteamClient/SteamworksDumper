namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sysz_op_type : uint
{
    SYSZ_OP_INVALID = 0,
    SYSZ_OP_REG,
    SYSZ_OP_IMM,
    SYSZ_OP_MEM,
    SYSZ_OP_ACREG = 64,
}
