namespace Rosentti.Capstone.Native;

public partial struct m68k_op_br_disp
{
    [NativeTypeName("int32_t")]
    public int disp;

    [NativeTypeName("uint8_t")]
    public byte disp_size;
}
