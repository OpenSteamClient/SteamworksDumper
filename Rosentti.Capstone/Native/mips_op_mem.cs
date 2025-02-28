namespace Rosentti.Capstone.Native;

public partial struct mips_op_mem
{
    public mips_reg @base;

    [NativeTypeName("int64_t")]
    public nint disp;
}
