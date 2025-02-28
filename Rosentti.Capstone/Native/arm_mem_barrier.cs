namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_mem_barrier : uint
{
    ARM_MB_INVALID = 0,
    ARM_MB_RESERVED_0,
    ARM_MB_OSHLD,
    ARM_MB_OSHST,
    ARM_MB_OSH,
    ARM_MB_RESERVED_4,
    ARM_MB_NSHLD,
    ARM_MB_NSHST,
    ARM_MB_NSH,
    ARM_MB_RESERVED_8,
    ARM_MB_ISHLD,
    ARM_MB_ISHST,
    ARM_MB_ISH,
    ARM_MB_RESERVED_12,
    ARM_MB_LD,
    ARM_MB_ST,
    ARM_MB_SY,
}
