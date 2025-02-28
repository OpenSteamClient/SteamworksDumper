using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_bpf
{
    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_bpf_op[4]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(4)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_bpf_op e0;
    }
}
