using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_m680x_op
{
    public m680x_op_type type;

    [NativeTypeName("__AnonymousRecord_m680x_L116_C2")]
    public _Anonymous_e__Union Anonymous;

    [NativeTypeName("uint8_t")]
    public byte size;

    [NativeTypeName("uint8_t")]
    public byte access;

    [UnscopedRef]
    public ref int imm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.imm;
        }
    }

    [UnscopedRef]
    public ref m680x_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

    [UnscopedRef]
    public ref m680x_op_idx idx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.idx;
        }
    }

    [UnscopedRef]
    public ref m680x_op_rel rel
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.rel;
        }
    }

    [UnscopedRef]
    public ref m680x_op_ext ext
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.ext;
        }
    }

    [UnscopedRef]
    public ref byte direct_addr
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.direct_addr;
        }
    }

    [UnscopedRef]
    public ref byte const_val
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.const_val;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int imm;

        [FieldOffset(0)]
        public m680x_reg reg;

        [FieldOffset(0)]
        public m680x_op_idx idx;

        [FieldOffset(0)]
        public m680x_op_rel rel;

        [FieldOffset(0)]
        public m680x_op_ext ext;

        [FieldOffset(0)]
        [NativeTypeName("uint8_t")]
        public byte direct_addr;

        [FieldOffset(0)]
        [NativeTypeName("uint8_t")]
        public byte const_val;
    }
}
