namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_insn_group : uint
{
    ARM64_GRP_INVALID = 0,
    ARM64_GRP_JUMP,
    ARM64_GRP_CALL,
    ARM64_GRP_RET,
    ARM64_GRP_INT,
    ARM64_GRP_PRIVILEGE = 6,
    ARM64_GRP_BRANCH_RELATIVE,
    ARM64_GRP_PAC,
    ARM64_GRP_CRYPTO = 128,
    ARM64_GRP_FPARMV8,
    ARM64_GRP_NEON,
    ARM64_GRP_CRC,
    ARM64_GRP_AES,
    ARM64_GRP_DOTPROD,
    ARM64_GRP_FULLFP16,
    ARM64_GRP_LSE,
    ARM64_GRP_RCPC,
    ARM64_GRP_RDM,
    ARM64_GRP_SHA2,
    ARM64_GRP_SHA3,
    ARM64_GRP_SM4,
    ARM64_GRP_SVE,
    ARM64_GRP_SVE2,
    ARM64_GRP_SVE2AES,
    ARM64_GRP_SVE2BitPerm,
    ARM64_GRP_SVE2SHA3,
    ARM64_GRP_SVE2SM4,
    ARM64_GRP_SME,
    ARM64_GRP_SMEF64,
    ARM64_GRP_SMEI64,
    ARM64_GRP_MatMulFP32,
    ARM64_GRP_MatMulFP64,
    ARM64_GRP_MatMulInt8,
    ARM64_GRP_V8_1A,
    ARM64_GRP_V8_3A,
    ARM64_GRP_V8_4A,
    ARM64_GRP_ENDING,
}
