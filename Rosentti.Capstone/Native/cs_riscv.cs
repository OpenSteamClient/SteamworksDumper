using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_riscv
{
    [NativeTypeName("bool")]
    public byte need_effective_addr;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_riscv_op[8]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(8)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_riscv_op e0;
    }
}
