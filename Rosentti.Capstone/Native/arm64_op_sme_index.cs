namespace Rosentti.Capstone.Native;

public partial struct arm64_op_sme_index
{
    public arm64_reg reg;

    public arm64_reg @base;

    [NativeTypeName("int32_t")]
    public int disp;
}
