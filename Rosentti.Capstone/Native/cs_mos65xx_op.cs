using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_mos65xx_op
{
    public mos65xx_op_type type;

    [NativeTypeName("__AnonymousRecord_mos65xx_L182_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref mos65xx_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

    [UnscopedRef]
    public ref ushort imm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.imm;
        }
    }

    [UnscopedRef]
    public ref uint mem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mem;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public mos65xx_reg reg;

        [FieldOffset(0)]
        [NativeTypeName("uint16_t")]
        public ushort imm;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint mem;
    }
}
