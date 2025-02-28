namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum cs_op_type : uint
{
    CS_OP_INVALID = 0,
    CS_OP_REG,
    CS_OP_IMM,
    CS_OP_MEM,
    CS_OP_FP,
}
