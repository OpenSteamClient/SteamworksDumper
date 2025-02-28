using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_wasm_op
{
    public wasm_op_type type;

    [NativeTypeName("uint32_t")]
    public uint size;

    [NativeTypeName("__AnonymousRecord_wasm_L38_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref sbyte int7
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.int7;
        }
    }

    [UnscopedRef]
    public ref uint varuint32
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.varuint32;
        }
    }

    [UnscopedRef]
    public ref nuint varuint64
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.varuint64;
        }
    }

    [UnscopedRef]
    public ref uint uint32
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.uint32;
        }
    }

    [UnscopedRef]
    public ref nuint uint64
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.uint64;
        }
    }

    [UnscopedRef]
    public Span<uint> immediate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return Anonymous.immediate;
        }
    }

    [UnscopedRef]
    public ref cs_wasm_brtable brtable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.brtable;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("int8_t")]
        public sbyte int7;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint varuint32;

        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint varuint64;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint uint32;

        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint uint64;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t[2]")]
        public _immediate_e__FixedBuffer immediate;

        [FieldOffset(0)]
        public cs_wasm_brtable brtable;

        [InlineArray(2)]
        public partial struct _immediate_e__FixedBuffer
        {
            public uint e0;
        }
    }
}
