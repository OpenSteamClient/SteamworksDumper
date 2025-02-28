namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum tms320c64x_insn_group : uint
{
    TMS320C64X_GRP_INVALID = 0,
    TMS320C64X_GRP_JUMP,
    TMS320C64X_GRP_FUNIT_D = 128,
    TMS320C64X_GRP_FUNIT_L,
    TMS320C64X_GRP_FUNIT_M,
    TMS320C64X_GRP_FUNIT_S,
    TMS320C64X_GRP_FUNIT_NO,
    TMS320C64X_GRP_ENDING,
}
