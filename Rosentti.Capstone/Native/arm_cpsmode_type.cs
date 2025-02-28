namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_cpsmode_type : uint
{
    ARM_CPSMODE_INVALID = 0,
    ARM_CPSMODE_IE = 2,
    ARM_CPSMODE_ID = 3,
}
