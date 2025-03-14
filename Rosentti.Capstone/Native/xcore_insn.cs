namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum xcore_insn : uint
{
    XCORE_INS_INVALID = 0,
    XCORE_INS_ADD,
    XCORE_INS_ANDNOT,
    XCORE_INS_AND,
    XCORE_INS_ASHR,
    XCORE_INS_BAU,
    XCORE_INS_BITREV,
    XCORE_INS_BLA,
    XCORE_INS_BLAT,
    XCORE_INS_BL,
    XCORE_INS_BF,
    XCORE_INS_BT,
    XCORE_INS_BU,
    XCORE_INS_BRU,
    XCORE_INS_BYTEREV,
    XCORE_INS_CHKCT,
    XCORE_INS_CLRE,
    XCORE_INS_CLRPT,
    XCORE_INS_CLRSR,
    XCORE_INS_CLZ,
    XCORE_INS_CRC8,
    XCORE_INS_CRC32,
    XCORE_INS_DCALL,
    XCORE_INS_DENTSP,
    XCORE_INS_DGETREG,
    XCORE_INS_DIVS,
    XCORE_INS_DIVU,
    XCORE_INS_DRESTSP,
    XCORE_INS_DRET,
    XCORE_INS_ECALLF,
    XCORE_INS_ECALLT,
    XCORE_INS_EDU,
    XCORE_INS_EEF,
    XCORE_INS_EET,
    XCORE_INS_EEU,
    XCORE_INS_ENDIN,
    XCORE_INS_ENTSP,
    XCORE_INS_EQ,
    XCORE_INS_EXTDP,
    XCORE_INS_EXTSP,
    XCORE_INS_FREER,
    XCORE_INS_FREET,
    XCORE_INS_GETD,
    XCORE_INS_GET,
    XCORE_INS_GETN,
    XCORE_INS_GETR,
    XCORE_INS_GETSR,
    XCORE_INS_GETST,
    XCORE_INS_GETTS,
    XCORE_INS_INCT,
    XCORE_INS_INIT,
    XCORE_INS_INPW,
    XCORE_INS_INSHR,
    XCORE_INS_INT,
    XCORE_INS_IN,
    XCORE_INS_KCALL,
    XCORE_INS_KENTSP,
    XCORE_INS_KRESTSP,
    XCORE_INS_KRET,
    XCORE_INS_LADD,
    XCORE_INS_LD16S,
    XCORE_INS_LD8U,
    XCORE_INS_LDA16,
    XCORE_INS_LDAP,
    XCORE_INS_LDAW,
    XCORE_INS_LDC,
    XCORE_INS_LDW,
    XCORE_INS_LDIVU,
    XCORE_INS_LMUL,
    XCORE_INS_LSS,
    XCORE_INS_LSUB,
    XCORE_INS_LSU,
    XCORE_INS_MACCS,
    XCORE_INS_MACCU,
    XCORE_INS_MJOIN,
    XCORE_INS_MKMSK,
    XCORE_INS_MSYNC,
    XCORE_INS_MUL,
    XCORE_INS_NEG,
    XCORE_INS_NOT,
    XCORE_INS_OR,
    XCORE_INS_OUTCT,
    XCORE_INS_OUTPW,
    XCORE_INS_OUTSHR,
    XCORE_INS_OUTT,
    XCORE_INS_OUT,
    XCORE_INS_PEEK,
    XCORE_INS_REMS,
    XCORE_INS_REMU,
    XCORE_INS_RETSP,
    XCORE_INS_SETCLK,
    XCORE_INS_SET,
    XCORE_INS_SETC,
    XCORE_INS_SETD,
    XCORE_INS_SETEV,
    XCORE_INS_SETN,
    XCORE_INS_SETPSC,
    XCORE_INS_SETPT,
    XCORE_INS_SETRDY,
    XCORE_INS_SETSR,
    XCORE_INS_SETTW,
    XCORE_INS_SETV,
    XCORE_INS_SEXT,
    XCORE_INS_SHL,
    XCORE_INS_SHR,
    XCORE_INS_SSYNC,
    XCORE_INS_ST16,
    XCORE_INS_ST8,
    XCORE_INS_STW,
    XCORE_INS_SUB,
    XCORE_INS_SYNCR,
    XCORE_INS_TESTCT,
    XCORE_INS_TESTLCL,
    XCORE_INS_TESTWCT,
    XCORE_INS_TSETMR,
    XCORE_INS_START,
    XCORE_INS_WAITEF,
    XCORE_INS_WAITET,
    XCORE_INS_WAITEU,
    XCORE_INS_XOR,
    XCORE_INS_ZEXT,
    XCORE_INS_ENDING,
}
