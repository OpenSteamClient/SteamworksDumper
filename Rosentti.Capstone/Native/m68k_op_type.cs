namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_op_type : uint
{
    M68K_OP_INVALID = 0,
    M68K_OP_REG,
    M68K_OP_IMM,
    M68K_OP_MEM,
    M68K_OP_FP_SINGLE,
    M68K_OP_FP_DOUBLE,
    M68K_OP_REG_BITS,
    M68K_OP_REG_PAIR,
    M68K_OP_BR_DISP,
}
