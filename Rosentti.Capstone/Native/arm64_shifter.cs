namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_shifter : uint
{
    ARM64_SFT_INVALID = 0,
    ARM64_SFT_LSL = 1,
    ARM64_SFT_MSL = 2,
    ARM64_SFT_LSR = 3,
    ARM64_SFT_ASR = 4,
    ARM64_SFT_ROR = 5,
}
