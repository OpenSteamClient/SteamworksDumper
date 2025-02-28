using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_sysz
{
    public sysz_cc cc;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_sysz_op[6]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(6)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_sysz_op e0;
    }
}
