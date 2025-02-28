namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_extender : uint
{
    ARM64_EXT_INVALID = 0,
    ARM64_EXT_UXTB = 1,
    ARM64_EXT_UXTH = 2,
    ARM64_EXT_UXTW = 3,
    ARM64_EXT_UXTX = 4,
    ARM64_EXT_SXTB = 5,
    ARM64_EXT_SXTH = 6,
    ARM64_EXT_SXTW = 7,
    ARM64_EXT_SXTX = 8,
}
