namespace Rosentti.Capstone.Native;

public partial struct cs_evm
{
    [NativeTypeName("unsigned char")]
    public byte pop;

    [NativeTypeName("unsigned char")]
    public byte push;

    [NativeTypeName("unsigned int")]
    public uint fee;
}
