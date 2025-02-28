namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum ppc_op_type : uint
{
    PPC_OP_INVALID = 0,
    PPC_OP_REG,
    PPC_OP_IMM,
    PPC_OP_MEM,
    PPC_OP_CRX = 64,
}
