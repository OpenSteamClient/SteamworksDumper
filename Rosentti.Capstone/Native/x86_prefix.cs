namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum x86_prefix : uint
{
    X86_PREFIX_LOCK = 0xf0,
    X86_PREFIX_REP = 0xf3,
    X86_PREFIX_REPE = 0xf3,
    X86_PREFIX_REPNE = 0xf2,
    X86_PREFIX_CS = 0x2e,
    X86_PREFIX_SS = 0x36,
    X86_PREFIX_DS = 0x3e,
    X86_PREFIX_ES = 0x26,
    X86_PREFIX_FS = 0x64,
    X86_PREFIX_GS = 0x65,
    X86_PREFIX_OPSIZE = 0x66,
    X86_PREFIX_ADDRSIZE = 0x67,
}
