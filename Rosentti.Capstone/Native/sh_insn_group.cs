namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sh_insn_group : uint
{
    SH_GRP_INVALID = 0,
    SH_GRP_JUMP,
    SH_GRP_CALL,
    SH_GRP_INT,
    SH_GRP_RET,
    SH_GRP_IRET,
    SH_GRP_PRIVILEGE,
    SH_GRP_BRANCH_RELATIVE,
    SH_GRP_SH1,
    SH_GRP_SH2,
    SH_GRP_SH2E,
    SH_GRP_SH2DSP,
    SH_GRP_SH2A,
    SH_GRP_SH2AFPU,
    SH_GRP_SH3,
    SH_GRP_SH3DSP,
    SH_GRP_SH4,
    SH_GRP_SH4A,
    SH_GRP_ENDING,
}
