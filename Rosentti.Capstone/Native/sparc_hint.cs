namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sparc_hint : uint
{
    SPARC_HINT_INVALID = 0,
    SPARC_HINT_A = 1 << 0,
    SPARC_HINT_PT = 1 << 1,
    SPARC_HINT_PN = 1 << 2,
}
