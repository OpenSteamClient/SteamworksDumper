using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_arm64
{
    public arm64_cc cc;

    [NativeTypeName("bool")]
    public byte update_flags;

    [NativeTypeName("bool")]
    public byte writeback;

    [NativeTypeName("bool")]
    public byte post_index;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_arm64_op[8]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(8)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_arm64_op e0;
    }
}
