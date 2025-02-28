namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m68k_op_br_disp_size : uint
{
    M68K_OP_BR_DISP_SIZE_INVALID = 0,
    M68K_OP_BR_DISP_SIZE_BYTE = 1,
    M68K_OP_BR_DISP_SIZE_WORD = 2,
    M68K_OP_BR_DISP_SIZE_LONG = 4,
}
