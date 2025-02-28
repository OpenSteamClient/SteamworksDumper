namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm64_barrier_op : uint
{
    ARM64_BARRIER_INVALID = 0,
    ARM64_BARRIER_OSHLD = 0x1,
    ARM64_BARRIER_OSHST = 0x2,
    ARM64_BARRIER_OSH = 0x3,
    ARM64_BARRIER_NSHLD = 0x5,
    ARM64_BARRIER_NSHST = 0x6,
    ARM64_BARRIER_NSH = 0x7,
    ARM64_BARRIER_ISHLD = 0x9,
    ARM64_BARRIER_ISHST = 0xa,
    ARM64_BARRIER_ISH = 0xb,
    ARM64_BARRIER_LD = 0xd,
    ARM64_BARRIER_ST = 0xe,
    ARM64_BARRIER_SY = 0xf,
}
