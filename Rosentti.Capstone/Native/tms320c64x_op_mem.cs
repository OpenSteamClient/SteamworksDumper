namespace Rosentti.Capstone.Native;

public partial struct tms320c64x_op_mem
{
    [NativeTypeName("unsigned int")]
    public uint @base;

    [NativeTypeName("unsigned int")]
    public uint disp;

    [NativeTypeName("unsigned int")]
    public uint unit;

    [NativeTypeName("unsigned int")]
    public uint scaled;

    [NativeTypeName("unsigned int")]
    public uint disptype;

    [NativeTypeName("unsigned int")]
    public uint direction;

    [NativeTypeName("unsigned int")]
    public uint modify;
}
