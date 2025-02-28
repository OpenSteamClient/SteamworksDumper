namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum riscv_op_type : uint
{
    RISCV_OP_INVALID = 0,
    RISCV_OP_REG,
    RISCV_OP_IMM,
    RISCV_OP_MEM,
}
