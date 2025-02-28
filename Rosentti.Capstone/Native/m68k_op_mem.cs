namespace Rosentti.Capstone.Native;

public partial struct m68k_op_mem
{
    public m68k_reg base_reg;

    public m68k_reg index_reg;

    public m68k_reg in_base_reg;

    [NativeTypeName("uint32_t")]
    public uint in_disp;

    [NativeTypeName("uint32_t")]
    public uint out_disp;

    [NativeTypeName("int16_t")]
    public short disp;

    [NativeTypeName("uint8_t")]
    public byte scale;

    [NativeTypeName("uint8_t")]
    public byte bitfield;

    [NativeTypeName("uint8_t")]
    public byte width;

    [NativeTypeName("uint8_t")]
    public byte offset;

    [NativeTypeName("uint8_t")]
    public byte index_size;
}
