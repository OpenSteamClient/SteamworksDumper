namespace Rosentti.Capstone.Native;

public partial struct x86_op_mem
{
    public x86_reg segment;

    public x86_reg @base;

    public x86_reg index;

    public int scale;

    [NativeTypeName("int64_t")]
    public nint disp;
}
