namespace Rosentti.Capstone.Native;

public partial struct sh_op_mem
{
    public sh_op_mem_type address;

    public sh_reg reg;

    [NativeTypeName("uint32_t")]
    public uint disp;
}
