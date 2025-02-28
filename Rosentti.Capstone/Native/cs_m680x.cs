using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_m680x
{
    [NativeTypeName("uint8_t")]
    public byte flags;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_m680x_op[9]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(9)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_m680x_op e0;
    }
}
