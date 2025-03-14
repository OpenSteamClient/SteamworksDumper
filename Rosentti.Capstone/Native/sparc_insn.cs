namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sparc_insn : uint
{
    SPARC_INS_INVALID = 0,
    SPARC_INS_ADDCC,
    SPARC_INS_ADDX,
    SPARC_INS_ADDXCC,
    SPARC_INS_ADDXC,
    SPARC_INS_ADDXCCC,
    SPARC_INS_ADD,
    SPARC_INS_ALIGNADDR,
    SPARC_INS_ALIGNADDRL,
    SPARC_INS_ANDCC,
    SPARC_INS_ANDNCC,
    SPARC_INS_ANDN,
    SPARC_INS_AND,
    SPARC_INS_ARRAY16,
    SPARC_INS_ARRAY32,
    SPARC_INS_ARRAY8,
    SPARC_INS_B,
    SPARC_INS_JMP,
    SPARC_INS_BMASK,
    SPARC_INS_FB,
    SPARC_INS_BRGEZ,
    SPARC_INS_BRGZ,
    SPARC_INS_BRLEZ,
    SPARC_INS_BRLZ,
    SPARC_INS_BRNZ,
    SPARC_INS_BRZ,
    SPARC_INS_BSHUFFLE,
    SPARC_INS_CALL,
    SPARC_INS_CASX,
    SPARC_INS_CAS,
    SPARC_INS_CMASK16,
    SPARC_INS_CMASK32,
    SPARC_INS_CMASK8,
    SPARC_INS_CMP,
    SPARC_INS_EDGE16,
    SPARC_INS_EDGE16L,
    SPARC_INS_EDGE16LN,
    SPARC_INS_EDGE16N,
    SPARC_INS_EDGE32,
    SPARC_INS_EDGE32L,
    SPARC_INS_EDGE32LN,
    SPARC_INS_EDGE32N,
    SPARC_INS_EDGE8,
    SPARC_INS_EDGE8L,
    SPARC_INS_EDGE8LN,
    SPARC_INS_EDGE8N,
    SPARC_INS_FABSD,
    SPARC_INS_FABSQ,
    SPARC_INS_FABSS,
    SPARC_INS_FADDD,
    SPARC_INS_FADDQ,
    SPARC_INS_FADDS,
    SPARC_INS_FALIGNDATA,
    SPARC_INS_FAND,
    SPARC_INS_FANDNOT1,
    SPARC_INS_FANDNOT1S,
    SPARC_INS_FANDNOT2,
    SPARC_INS_FANDNOT2S,
    SPARC_INS_FANDS,
    SPARC_INS_FCHKSM16,
    SPARC_INS_FCMPD,
    SPARC_INS_FCMPEQ16,
    SPARC_INS_FCMPEQ32,
    SPARC_INS_FCMPGT16,
    SPARC_INS_FCMPGT32,
    SPARC_INS_FCMPLE16,
    SPARC_INS_FCMPLE32,
    SPARC_INS_FCMPNE16,
    SPARC_INS_FCMPNE32,
    SPARC_INS_FCMPQ,
    SPARC_INS_FCMPS,
    SPARC_INS_FDIVD,
    SPARC_INS_FDIVQ,
    SPARC_INS_FDIVS,
    SPARC_INS_FDMULQ,
    SPARC_INS_FDTOI,
    SPARC_INS_FDTOQ,
    SPARC_INS_FDTOS,
    SPARC_INS_FDTOX,
    SPARC_INS_FEXPAND,
    SPARC_INS_FHADDD,
    SPARC_INS_FHADDS,
    SPARC_INS_FHSUBD,
    SPARC_INS_FHSUBS,
    SPARC_INS_FITOD,
    SPARC_INS_FITOQ,
    SPARC_INS_FITOS,
    SPARC_INS_FLCMPD,
    SPARC_INS_FLCMPS,
    SPARC_INS_FLUSHW,
    SPARC_INS_FMEAN16,
    SPARC_INS_FMOVD,
    SPARC_INS_FMOVQ,
    SPARC_INS_FMOVRDGEZ,
    SPARC_INS_FMOVRQGEZ,
    SPARC_INS_FMOVRSGEZ,
    SPARC_INS_FMOVRDGZ,
    SPARC_INS_FMOVRQGZ,
    SPARC_INS_FMOVRSGZ,
    SPARC_INS_FMOVRDLEZ,
    SPARC_INS_FMOVRQLEZ,
    SPARC_INS_FMOVRSLEZ,
    SPARC_INS_FMOVRDLZ,
    SPARC_INS_FMOVRQLZ,
    SPARC_INS_FMOVRSLZ,
    SPARC_INS_FMOVRDNZ,
    SPARC_INS_FMOVRQNZ,
    SPARC_INS_FMOVRSNZ,
    SPARC_INS_FMOVRDZ,
    SPARC_INS_FMOVRQZ,
    SPARC_INS_FMOVRSZ,
    SPARC_INS_FMOVS,
    SPARC_INS_FMUL8SUX16,
    SPARC_INS_FMUL8ULX16,
    SPARC_INS_FMUL8X16,
    SPARC_INS_FMUL8X16AL,
    SPARC_INS_FMUL8X16AU,
    SPARC_INS_FMULD,
    SPARC_INS_FMULD8SUX16,
    SPARC_INS_FMULD8ULX16,
    SPARC_INS_FMULQ,
    SPARC_INS_FMULS,
    SPARC_INS_FNADDD,
    SPARC_INS_FNADDS,
    SPARC_INS_FNAND,
    SPARC_INS_FNANDS,
    SPARC_INS_FNEGD,
    SPARC_INS_FNEGQ,
    SPARC_INS_FNEGS,
    SPARC_INS_FNHADDD,
    SPARC_INS_FNHADDS,
    SPARC_INS_FNOR,
    SPARC_INS_FNORS,
    SPARC_INS_FNOT1,
    SPARC_INS_FNOT1S,
    SPARC_INS_FNOT2,
    SPARC_INS_FNOT2S,
    SPARC_INS_FONE,
    SPARC_INS_FONES,
    SPARC_INS_FOR,
    SPARC_INS_FORNOT1,
    SPARC_INS_FORNOT1S,
    SPARC_INS_FORNOT2,
    SPARC_INS_FORNOT2S,
    SPARC_INS_FORS,
    SPARC_INS_FPACK16,
    SPARC_INS_FPACK32,
    SPARC_INS_FPACKFIX,
    SPARC_INS_FPADD16,
    SPARC_INS_FPADD16S,
    SPARC_INS_FPADD32,
    SPARC_INS_FPADD32S,
    SPARC_INS_FPADD64,
    SPARC_INS_FPMERGE,
    SPARC_INS_FPSUB16,
    SPARC_INS_FPSUB16S,
    SPARC_INS_FPSUB32,
    SPARC_INS_FPSUB32S,
    SPARC_INS_FQTOD,
    SPARC_INS_FQTOI,
    SPARC_INS_FQTOS,
    SPARC_INS_FQTOX,
    SPARC_INS_FSLAS16,
    SPARC_INS_FSLAS32,
    SPARC_INS_FSLL16,
    SPARC_INS_FSLL32,
    SPARC_INS_FSMULD,
    SPARC_INS_FSQRTD,
    SPARC_INS_FSQRTQ,
    SPARC_INS_FSQRTS,
    SPARC_INS_FSRA16,
    SPARC_INS_FSRA32,
    SPARC_INS_FSRC1,
    SPARC_INS_FSRC1S,
    SPARC_INS_FSRC2,
    SPARC_INS_FSRC2S,
    SPARC_INS_FSRL16,
    SPARC_INS_FSRL32,
    SPARC_INS_FSTOD,
    SPARC_INS_FSTOI,
    SPARC_INS_FSTOQ,
    SPARC_INS_FSTOX,
    SPARC_INS_FSUBD,
    SPARC_INS_FSUBQ,
    SPARC_INS_FSUBS,
    SPARC_INS_FXNOR,
    SPARC_INS_FXNORS,
    SPARC_INS_FXOR,
    SPARC_INS_FXORS,
    SPARC_INS_FXTOD,
    SPARC_INS_FXTOQ,
    SPARC_INS_FXTOS,
    SPARC_INS_FZERO,
    SPARC_INS_FZEROS,
    SPARC_INS_JMPL,
    SPARC_INS_LDD,
    SPARC_INS_LD,
    SPARC_INS_LDQ,
    SPARC_INS_LDSB,
    SPARC_INS_LDSH,
    SPARC_INS_LDSW,
    SPARC_INS_LDUB,
    SPARC_INS_LDUH,
    SPARC_INS_LDX,
    SPARC_INS_LZCNT,
    SPARC_INS_MEMBAR,
    SPARC_INS_MOVDTOX,
    SPARC_INS_MOV,
    SPARC_INS_MOVRGEZ,
    SPARC_INS_MOVRGZ,
    SPARC_INS_MOVRLEZ,
    SPARC_INS_MOVRLZ,
    SPARC_INS_MOVRNZ,
    SPARC_INS_MOVRZ,
    SPARC_INS_MOVSTOSW,
    SPARC_INS_MOVSTOUW,
    SPARC_INS_MULX,
    SPARC_INS_NOP,
    SPARC_INS_ORCC,
    SPARC_INS_ORNCC,
    SPARC_INS_ORN,
    SPARC_INS_OR,
    SPARC_INS_PDIST,
    SPARC_INS_PDISTN,
    SPARC_INS_POPC,
    SPARC_INS_RD,
    SPARC_INS_RESTORE,
    SPARC_INS_RETT,
    SPARC_INS_SAVE,
    SPARC_INS_SDIVCC,
    SPARC_INS_SDIVX,
    SPARC_INS_SDIV,
    SPARC_INS_SETHI,
    SPARC_INS_SHUTDOWN,
    SPARC_INS_SIAM,
    SPARC_INS_SLLX,
    SPARC_INS_SLL,
    SPARC_INS_SMULCC,
    SPARC_INS_SMUL,
    SPARC_INS_SRAX,
    SPARC_INS_SRA,
    SPARC_INS_SRLX,
    SPARC_INS_SRL,
    SPARC_INS_STBAR,
    SPARC_INS_STB,
    SPARC_INS_STD,
    SPARC_INS_ST,
    SPARC_INS_STH,
    SPARC_INS_STQ,
    SPARC_INS_STX,
    SPARC_INS_SUBCC,
    SPARC_INS_SUBX,
    SPARC_INS_SUBXCC,
    SPARC_INS_SUB,
    SPARC_INS_SWAP,
    SPARC_INS_TADDCCTV,
    SPARC_INS_TADDCC,
    SPARC_INS_T,
    SPARC_INS_TSUBCCTV,
    SPARC_INS_TSUBCC,
    SPARC_INS_UDIVCC,
    SPARC_INS_UDIVX,
    SPARC_INS_UDIV,
    SPARC_INS_UMULCC,
    SPARC_INS_UMULXHI,
    SPARC_INS_UMUL,
    SPARC_INS_UNIMP,
    SPARC_INS_FCMPED,
    SPARC_INS_FCMPEQ,
    SPARC_INS_FCMPES,
    SPARC_INS_WR,
    SPARC_INS_XMULX,
    SPARC_INS_XMULXHI,
    SPARC_INS_XNORCC,
    SPARC_INS_XNOR,
    SPARC_INS_XORCC,
    SPARC_INS_XOR,
    SPARC_INS_RET,
    SPARC_INS_RETL,
    SPARC_INS_ENDING,
}
