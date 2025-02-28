namespace Rosentti.Capstone.Native;

public partial struct arm_op_mem
{
    public arm_reg @base;

    public arm_reg index;

    public int scale;

    public int disp;

    public int lshift;
}
