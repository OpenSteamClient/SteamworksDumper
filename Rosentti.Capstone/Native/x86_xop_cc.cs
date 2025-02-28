namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum x86_xop_cc : uint
{
    X86_XOP_CC_INVALID = 0,
    X86_XOP_CC_LT,
    X86_XOP_CC_LE,
    X86_XOP_CC_GT,
    X86_XOP_CC_GE,
    X86_XOP_CC_EQ,
    X86_XOP_CC_NEQ,
    X86_XOP_CC_FALSE,
    X86_XOP_CC_TRUE,
}
