using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_mips
{
    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_mips_op[10]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(10)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_mips_op e0;
    }
}
