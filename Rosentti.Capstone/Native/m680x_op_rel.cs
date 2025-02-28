namespace Rosentti.Capstone.Native;

public partial struct m680x_op_rel
{
    [NativeTypeName("uint16_t")]
    public ushort address;

    [NativeTypeName("int16_t")]
    public short offset;
}
