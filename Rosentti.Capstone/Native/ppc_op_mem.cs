namespace Rosentti.Capstone.Native;

public partial struct ppc_op_mem
{
    public ppc_reg @base;

    [NativeTypeName("int32_t")]
    public int disp;
}
