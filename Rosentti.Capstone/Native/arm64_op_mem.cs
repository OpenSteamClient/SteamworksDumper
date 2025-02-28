namespace Rosentti.Capstone.Native;

public partial struct arm64_op_mem
{
    public arm64_reg @base;

    public arm64_reg index;

    [NativeTypeName("int32_t")]
    public int disp;
}
