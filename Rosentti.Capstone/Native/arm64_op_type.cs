namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_op_type : uint
{
    ARM64_OP_INVALID = 0,
    ARM64_OP_REG,
    ARM64_OP_IMM,
    ARM64_OP_MEM,
    ARM64_OP_FP,
    ARM64_OP_CIMM = 64,
    ARM64_OP_REG_MRS,
    ARM64_OP_REG_MSR,
    ARM64_OP_PSTATE,
    ARM64_OP_SYS,
    ARM64_OP_SVCR,
    ARM64_OP_PREFETCH,
    ARM64_OP_BARRIER,
    ARM64_OP_SME_INDEX,
}
