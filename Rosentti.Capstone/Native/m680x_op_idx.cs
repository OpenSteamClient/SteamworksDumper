namespace Rosentti.Capstone.Native;

public partial struct m680x_op_idx
{
    public m680x_reg base_reg;

    public m680x_reg offset_reg;

    [NativeTypeName("int16_t")]
    public short offset;

    [NativeTypeName("uint16_t")]
    public ushort offset_addr;

    [NativeTypeName("uint8_t")]
    public byte offset_bits;

    [NativeTypeName("int8_t")]
    public sbyte inc_dec;

    [NativeTypeName("uint8_t")]
    public byte flags;
}
