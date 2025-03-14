namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sh_insn : uint
{
    SH_INS_INVALID,
    SH_INS_ADD_r,
    SH_INS_ADD,
    SH_INS_ADDC,
    SH_INS_ADDV,
    SH_INS_AND,
    SH_INS_BAND,
    SH_INS_BANDNOT,
    SH_INS_BCLR,
    SH_INS_BF,
    SH_INS_BF_S,
    SH_INS_BLD,
    SH_INS_BLDNOT,
    SH_INS_BOR,
    SH_INS_BORNOT,
    SH_INS_BRA,
    SH_INS_BRAF,
    SH_INS_BSET,
    SH_INS_BSR,
    SH_INS_BSRF,
    SH_INS_BST,
    SH_INS_BT,
    SH_INS_BT_S,
    SH_INS_BXOR,
    SH_INS_CLIPS,
    SH_INS_CLIPU,
    SH_INS_CLRDMXY,
    SH_INS_CLRMAC,
    SH_INS_CLRS,
    SH_INS_CLRT,
    SH_INS_CMP_EQ,
    SH_INS_CMP_GE,
    SH_INS_CMP_GT,
    SH_INS_CMP_HI,
    SH_INS_CMP_HS,
    SH_INS_CMP_PL,
    SH_INS_CMP_PZ,
    SH_INS_CMP_STR,
    SH_INS_DIV0S,
    SH_INS_DIV0U,
    SH_INS_DIV1,
    SH_INS_DIVS,
    SH_INS_DIVU,
    SH_INS_DMULS_L,
    SH_INS_DMULU_L,
    SH_INS_DT,
    SH_INS_EXTS_B,
    SH_INS_EXTS_W,
    SH_INS_EXTU_B,
    SH_INS_EXTU_W,
    SH_INS_FABS,
    SH_INS_FADD,
    SH_INS_FCMP_EQ,
    SH_INS_FCMP_GT,
    SH_INS_FCNVDS,
    SH_INS_FCNVSD,
    SH_INS_FDIV,
    SH_INS_FIPR,
    SH_INS_FLDI0,
    SH_INS_FLDI1,
    SH_INS_FLDS,
    SH_INS_FLOAT,
    SH_INS_FMAC,
    SH_INS_FMOV,
    SH_INS_FMUL,
    SH_INS_FNEG,
    SH_INS_FPCHG,
    SH_INS_FRCHG,
    SH_INS_FSCA,
    SH_INS_FSCHG,
    SH_INS_FSQRT,
    SH_INS_FSRRA,
    SH_INS_FSTS,
    SH_INS_FSUB,
    SH_INS_FTRC,
    SH_INS_FTRV,
    SH_INS_ICBI,
    SH_INS_JMP,
    SH_INS_JSR,
    SH_INS_JSR_N,
    SH_INS_LDBANK,
    SH_INS_LDC,
    SH_INS_LDRC,
    SH_INS_LDRE,
    SH_INS_LDRS,
    SH_INS_LDS,
    SH_INS_LDTLB,
    SH_INS_MAC_L,
    SH_INS_MAC_W,
    SH_INS_MOV,
    SH_INS_MOVA,
    SH_INS_MOVCA,
    SH_INS_MOVCO,
    SH_INS_MOVI20,
    SH_INS_MOVI20S,
    SH_INS_MOVLI,
    SH_INS_MOVML,
    SH_INS_MOVMU,
    SH_INS_MOVRT,
    SH_INS_MOVT,
    SH_INS_MOVU,
    SH_INS_MOVUA,
    SH_INS_MUL_L,
    SH_INS_MULR,
    SH_INS_MULS_W,
    SH_INS_MULU_W,
    SH_INS_NEG,
    SH_INS_NEGC,
    SH_INS_NOP,
    SH_INS_NOT,
    SH_INS_NOTT,
    SH_INS_OCBI,
    SH_INS_OCBP,
    SH_INS_OCBWB,
    SH_INS_OR,
    SH_INS_PREF,
    SH_INS_PREFI,
    SH_INS_RESBANK,
    SH_INS_ROTCL,
    SH_INS_ROTCR,
    SH_INS_ROTL,
    SH_INS_ROTR,
    SH_INS_RTE,
    SH_INS_RTS,
    SH_INS_RTS_N,
    SH_INS_RTV_N,
    SH_INS_SETDMX,
    SH_INS_SETDMY,
    SH_INS_SETRC,
    SH_INS_SETS,
    SH_INS_SETT,
    SH_INS_SHAD,
    SH_INS_SHAL,
    SH_INS_SHAR,
    SH_INS_SHLD,
    SH_INS_SHLL,
    SH_INS_SHLL16,
    SH_INS_SHLL2,
    SH_INS_SHLL8,
    SH_INS_SHLR,
    SH_INS_SHLR16,
    SH_INS_SHLR2,
    SH_INS_SHLR8,
    SH_INS_SLEEP,
    SH_INS_STBANK,
    SH_INS_STC,
    SH_INS_STS,
    SH_INS_SUB,
    SH_INS_SUBC,
    SH_INS_SUBV,
    SH_INS_SWAP_B,
    SH_INS_SWAP_W,
    SH_INS_SYNCO,
    SH_INS_TAS,
    SH_INS_TRAPA,
    SH_INS_TST,
    SH_INS_XOR,
    SH_INS_XTRCT,
    SH_INS_DSP,
    SH_INS_ENDING,
}
