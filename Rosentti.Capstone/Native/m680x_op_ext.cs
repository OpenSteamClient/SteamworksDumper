namespace Rosentti.Capstone.Native;

public partial struct m680x_op_ext
{
    [NativeTypeName("uint16_t")]
    public ushort address;

    [NativeTypeName("bool")]
    public byte indirect;
}
