namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum xcore_insn_group : uint
{
    XCORE_GRP_INVALID = 0,
    XCORE_GRP_JUMP,
    XCORE_GRP_ENDING,
}
