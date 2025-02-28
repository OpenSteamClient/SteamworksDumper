namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sh_op_type : uint
{
    SH_OP_INVALID = 0,
    SH_OP_REG,
    SH_OP_IMM,
    SH_OP_MEM,
}
