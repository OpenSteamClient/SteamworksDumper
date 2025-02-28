namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum x86_op_type : uint
{
    X86_OP_INVALID = 0,
    X86_OP_REG,
    X86_OP_IMM,
    X86_OP_MEM,
}
