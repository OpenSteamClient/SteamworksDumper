namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_op_type : uint
{
    ARM_OP_INVALID = 0,
    ARM_OP_REG,
    ARM_OP_IMM,
    ARM_OP_MEM,
    ARM_OP_FP,
    ARM_OP_CIMM = 64,
    ARM_OP_PIMM,
    ARM_OP_SETEND,
    ARM_OP_SYSREG,
}
