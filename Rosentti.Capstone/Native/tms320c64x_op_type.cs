namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum tms320c64x_op_type : uint
{
    TMS320C64X_OP_INVALID = 0,
    TMS320C64X_OP_REG,
    TMS320C64X_OP_IMM,
    TMS320C64X_OP_MEM,
    TMS320C64X_OP_REGPAIR = 64,
}
