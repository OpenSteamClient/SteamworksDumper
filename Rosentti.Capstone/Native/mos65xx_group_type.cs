namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum mos65xx_group_type : uint
{
    MOS65XX_GRP_INVALID = 0,
    MOS65XX_GRP_JUMP,
    MOS65XX_GRP_CALL,
    MOS65XX_GRP_RET,
    MOS65XX_GRP_INT,
    MOS65XX_GRP_IRET = 5,
    MOS65XX_GRP_BRANCH_RELATIVE = 6,
    MOS65XX_GRP_ENDING,
}
