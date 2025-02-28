namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum wasm_op_type : uint
{
    WASM_OP_INVALID = 0,
    WASM_OP_NONE,
    WASM_OP_INT7,
    WASM_OP_VARUINT32,
    WASM_OP_VARUINT64,
    WASM_OP_UINT32,
    WASM_OP_UINT64,
    WASM_OP_IMM,
    WASM_OP_BRTABLE,
}
