namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_pstate : uint
{
    ARM64_PSTATE_INVALID = 0,
    ARM64_PSTATE_SPSEL = 0x05,
    ARM64_PSTATE_DAIFSET = 0x1e,
    ARM64_PSTATE_DAIFCLR = 0x1f,
    ARM64_PSTATE_PAN = 0x4,
    ARM64_PSTATE_UAO = 0x3,
    ARM64_PSTATE_DIT = 0x1a,
}
