namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum mos65xx_op_type : uint
{
    MOS65XX_OP_INVALID = 0,
    MOS65XX_OP_REG,
    MOS65XX_OP_IMM,
    MOS65XX_OP_MEM,
}
