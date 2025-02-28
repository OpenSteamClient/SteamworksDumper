namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sparc_op_type : uint
{
    SPARC_OP_INVALID = 0,
    SPARC_OP_REG,
    SPARC_OP_IMM,
    SPARC_OP_MEM,
}
