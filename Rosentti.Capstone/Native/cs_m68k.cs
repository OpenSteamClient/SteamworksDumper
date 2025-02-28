using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_m68k
{
    [NativeTypeName("cs_m68k_op[4]")]
    public _operands_e__FixedBuffer operands;

    public m68k_op_size op_size;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [InlineArray(4)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_m68k_op e0;
    }
}
