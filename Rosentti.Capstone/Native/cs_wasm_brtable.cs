namespace Rosentti.Capstone.Native;

public partial struct cs_wasm_brtable
{
    [NativeTypeName("uint32_t")]
    public uint length;

    [NativeTypeName("uint64_t")]
    public nuint address;

    [NativeTypeName("uint32_t")]
    public uint default_target;
}
