namespace Rosentti.Capstone.Native;

public partial struct cs_x86_encoding
{
    [NativeTypeName("uint8_t")]
    public byte modrm_offset;

    [NativeTypeName("uint8_t")]
    public byte disp_offset;

    [NativeTypeName("uint8_t")]
    public byte disp_size;

    [NativeTypeName("uint8_t")]
    public byte imm_offset;

    [NativeTypeName("uint8_t")]
    public byte imm_size;
}
