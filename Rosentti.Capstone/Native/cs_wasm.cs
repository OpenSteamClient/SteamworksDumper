using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_wasm
{
    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_wasm_op[2]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(2)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_wasm_op e0;
    }
}
