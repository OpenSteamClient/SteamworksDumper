namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sh_dsp_operand : uint
{
    SH_OP_DSP_INVALID,
    SH_OP_DSP_REG_PRE,
    SH_OP_DSP_REG_IND,
    SH_OP_DSP_REG_POST,
    SH_OP_DSP_REG_INDEX,
    SH_OP_DSP_REG,
    SH_OP_DSP_IMM,
}
