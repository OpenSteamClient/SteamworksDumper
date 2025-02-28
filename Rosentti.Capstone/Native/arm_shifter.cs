namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_shifter : uint
{
    ARM_SFT_INVALID = 0,
    ARM_SFT_ASR,
    ARM_SFT_LSL,
    ARM_SFT_LSR,
    ARM_SFT_ROR,
    ARM_SFT_RRX,
    ARM_SFT_ASR_REG,
    ARM_SFT_LSL_REG,
    ARM_SFT_LSR_REG,
    ARM_SFT_ROR_REG,
    ARM_SFT_RRX_REG,
}
