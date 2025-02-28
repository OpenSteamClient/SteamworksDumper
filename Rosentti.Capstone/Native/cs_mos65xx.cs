using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_mos65xx
{
    public mos65xx_address_mode am;

    [NativeTypeName("bool")]
    public byte modifies_flags;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_mos65xx_op[3]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(3)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_mos65xx_op e0;
    }
}
