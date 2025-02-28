using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_bpf_op
{
    public bpf_op_type type;

    [NativeTypeName("__AnonymousRecord_bpf_L70_C2")]
    public _Anonymous_e__Union Anonymous;

    [NativeTypeName("uint8_t")]
    public byte access;

    [UnscopedRef]
    public ref byte reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

    [UnscopedRef]
    public ref nuint imm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.imm;
        }
    }

    [UnscopedRef]
    public ref uint off
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.off;
        }
    }

    [UnscopedRef]
    public ref bpf_op_mem mem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mem;
        }
    }

    [UnscopedRef]
    public ref uint mmem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mmem;
        }
    }

    [UnscopedRef]
    public ref uint msh
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.msh;
        }
    }

    [UnscopedRef]
    public ref uint ext
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.ext;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("uint8_t")]
        public byte reg;

        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint imm;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint off;

        [FieldOffset(0)]
        public bpf_op_mem mem;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint mmem;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint msh;

        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint ext;
    }
}
