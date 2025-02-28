namespace Rosentti.Capstone.Native;

public partial struct ppc_op_crx
{
    [NativeTypeName("unsigned int")]
    public uint scale;

    public ppc_reg reg;

    public ppc_bc cond;
}
