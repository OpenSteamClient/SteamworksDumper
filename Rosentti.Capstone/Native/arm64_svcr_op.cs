namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_svcr_op : uint
{
    ARM64_SVCR_INVALID = 0,
    ARM64_SVCR_SVCRSM = 0x1,
    ARM64_SVCR_SVCRSMZA = 0x3,
    ARM64_SVCR_SVCRZA = 0x2,
}
