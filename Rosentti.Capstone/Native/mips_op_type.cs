namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum mips_op_type : uint
{
    MIPS_OP_INVALID = 0,
    MIPS_OP_REG,
    MIPS_OP_IMM,
    MIPS_OP_MEM,
}
