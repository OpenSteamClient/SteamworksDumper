namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum sh_dsp_insn_type : uint
{
    SH_INS_DSP_INVALID,
    SH_INS_DSP_DOUBLE,
    SH_INS_DSP_SINGLE,
    SH_INS_DSP_PARALLEL,
}
