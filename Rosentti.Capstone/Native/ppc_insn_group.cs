namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum ppc_insn_group : uint
{
    PPC_GRP_INVALID = 0,
    PPC_GRP_JUMP,
    PPC_GRP_ALTIVEC = 128,
    PPC_GRP_MODE32,
    PPC_GRP_MODE64,
    PPC_GRP_BOOKE,
    PPC_GRP_NOTBOOKE,
    PPC_GRP_SPE,
    PPC_GRP_VSX,
    PPC_GRP_E500,
    PPC_GRP_PPC4XX,
    PPC_GRP_PPC6XX,
    PPC_GRP_ICBT,
    PPC_GRP_P8ALTIVEC,
    PPC_GRP_P8VECTOR,
    PPC_GRP_QPX,
    PPC_GRP_PS,
    PPC_GRP_ENDING,
}
