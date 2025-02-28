namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_setend_type : uint
{
    ARM_SETEND_INVALID = 0,
    ARM_SETEND_BE,
    ARM_SETEND_LE,
}
