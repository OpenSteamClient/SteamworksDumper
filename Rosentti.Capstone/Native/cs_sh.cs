using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_sh
{
    public sh_insn insn;

    [NativeTypeName("uint8_t")]
    public byte size;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_sh_op[3]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(3)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_sh_op e0;
    }
}
