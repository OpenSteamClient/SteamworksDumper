namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_reg : uint
{
    M68K_REG_INVALID = 0,
    M68K_REG_D0,
    M68K_REG_D1,
    M68K_REG_D2,
    M68K_REG_D3,
    M68K_REG_D4,
    M68K_REG_D5,
    M68K_REG_D6,
    M68K_REG_D7,
    M68K_REG_A0,
    M68K_REG_A1,
    M68K_REG_A2,
    M68K_REG_A3,
    M68K_REG_A4,
    M68K_REG_A5,
    M68K_REG_A6,
    M68K_REG_A7,
    M68K_REG_FP0,
    M68K_REG_FP1,
    M68K_REG_FP2,
    M68K_REG_FP3,
    M68K_REG_FP4,
    M68K_REG_FP5,
    M68K_REG_FP6,
    M68K_REG_FP7,
    M68K_REG_PC,
    M68K_REG_SR,
    M68K_REG_CCR,
    M68K_REG_SFC,
    M68K_REG_DFC,
    M68K_REG_USP,
    M68K_REG_VBR,
    M68K_REG_CACR,
    M68K_REG_CAAR,
    M68K_REG_MSP,
    M68K_REG_ISP,
    M68K_REG_TC,
    M68K_REG_ITT0,
    M68K_REG_ITT1,
    M68K_REG_DTT0,
    M68K_REG_DTT1,
    M68K_REG_MMUSR,
    M68K_REG_URP,
    M68K_REG_SRP,
    M68K_REG_FPCR,
    M68K_REG_FPSR,
    M68K_REG_FPIAR,
    M68K_REG_ENDING,
}
