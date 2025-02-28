using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct sh_op_dsp
{
    public sh_dsp_insn insn;

    [NativeTypeName("sh_dsp_operand[2]")]
    public _operand_e__FixedBuffer operand;

    [NativeTypeName("sh_reg[6]")]
    public _r_e__FixedBuffer r;

    public sh_dsp_cc cc;

    [NativeTypeName("uint8_t")]
    public byte imm;

    public int size;

    [InlineArray(2)]
    public partial struct _operand_e__FixedBuffer
    {
        public sh_dsp_operand e0;
    }

    [InlineArray(6)]
    public partial struct _r_e__FixedBuffer
    {
        public sh_reg e0;
    }
}
