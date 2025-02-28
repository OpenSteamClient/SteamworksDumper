namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum mos65xx_reg : uint
{
    MOS65XX_REG_INVALID = 0,
    MOS65XX_REG_ACC,
    MOS65XX_REG_X,
    MOS65XX_REG_Y,
    MOS65XX_REG_P,
    MOS65XX_REG_SP,
    MOS65XX_REG_DP,
    MOS65XX_REG_B,
    MOS65XX_REG_K,
    MOS65XX_REG_ENDING,
}
