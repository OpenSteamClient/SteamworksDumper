namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_cpsflag_type : uint
{
    ARM_CPSFLAG_INVALID = 0,
    ARM_CPSFLAG_F = 1,
    ARM_CPSFLAG_I = 2,
    ARM_CPSFLAG_A = 4,
    ARM_CPSFLAG_NONE = 16,
}
