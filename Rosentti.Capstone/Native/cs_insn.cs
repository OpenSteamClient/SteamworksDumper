using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public unsafe partial struct cs_insn
{
    [NativeTypeName("unsigned int")]
    public uint id;

    [NativeTypeName("uint64_t")]
    public nuint address;

    [NativeTypeName("uint16_t")]
    public ushort size;

    [NativeTypeName("uint8_t[24]")]
    public _bytes_e__FixedBuffer bytes;

    [NativeTypeName("char[32]")]
    public _mnemonic_e__FixedBuffer mnemonic;

    [NativeTypeName("char[160]")]
    public _op_str_e__FixedBuffer op_str;

    public cs_detail* detail;

    [InlineArray(24)]
    public partial struct _bytes_e__FixedBuffer
    {
        public byte e0;
    }

    [InlineArray(32)]
    public partial struct _mnemonic_e__FixedBuffer
    {
        public sbyte e0;
    }

    [InlineArray(160)]
    public partial struct _op_str_e__FixedBuffer
    {
        public sbyte e0;
    }
}
