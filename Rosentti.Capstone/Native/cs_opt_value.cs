namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum cs_opt_value : uint
{
    CS_OPT_OFF = 0,
    CS_OPT_ON = 3,
    CS_OPT_SYNTAX_DEFAULT = 0,
    CS_OPT_SYNTAX_INTEL,
    CS_OPT_SYNTAX_ATT,
    CS_OPT_SYNTAX_NOREGNAME,
    CS_OPT_SYNTAX_MASM,
    CS_OPT_SYNTAX_MOTOROLA,
}
