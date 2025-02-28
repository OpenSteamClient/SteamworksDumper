namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum x86_sse_cc : uint
{
    X86_SSE_CC_INVALID = 0,
    X86_SSE_CC_EQ,
    X86_SSE_CC_LT,
    X86_SSE_CC_LE,
    X86_SSE_CC_UNORD,
    X86_SSE_CC_NEQ,
    X86_SSE_CC_NLT,
    X86_SSE_CC_NLE,
    X86_SSE_CC_ORD,
}
