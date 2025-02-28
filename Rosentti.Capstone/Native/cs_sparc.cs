using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_sparc
{
    public sparc_cc cc;

    public sparc_hint hint;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_sparc_op[4]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(4)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_sparc_op e0;
    }
}
