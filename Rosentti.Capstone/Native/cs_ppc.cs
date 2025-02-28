using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_ppc
{
    public ppc_bc bc;

    public ppc_bh bh;

    [NativeTypeName("bool")]
    public byte update_cr0;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_ppc_op[8]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(8)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_ppc_op e0;
    }
}
