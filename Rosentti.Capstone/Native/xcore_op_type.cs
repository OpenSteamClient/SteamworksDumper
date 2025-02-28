namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum xcore_op_type : uint
{
    XCORE_OP_INVALID = 0,
    XCORE_OP_REG,
    XCORE_OP_IMM,
    XCORE_OP_MEM,
}
