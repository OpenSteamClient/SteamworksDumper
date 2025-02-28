namespace Rosentti.Capstone.Native;

public partial struct sysz_op_mem
{
    [NativeTypeName("uint8_t")]
    public byte @base;

    [NativeTypeName("uint8_t")]
    public byte index;

    [NativeTypeName("uint64_t")]
    public nuint length;

    [NativeTypeName("int64_t")]
    public nint disp;
}
