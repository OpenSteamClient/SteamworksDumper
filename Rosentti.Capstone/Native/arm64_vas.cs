namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_vas : uint
{
    ARM64_VAS_INVALID = 0,
    ARM64_VAS_16B,
    ARM64_VAS_8B,
    ARM64_VAS_4B,
    ARM64_VAS_1B,
    ARM64_VAS_8H,
    ARM64_VAS_4H,
    ARM64_VAS_2H,
    ARM64_VAS_1H,
    ARM64_VAS_4S,
    ARM64_VAS_2S,
    ARM64_VAS_1S,
    ARM64_VAS_2D,
    ARM64_VAS_1D,
    ARM64_VAS_1Q,
}
