using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_arm64_op
{
    public int vector_index;

    public arm64_vas vas;

    [NativeTypeName("__AnonymousRecord_arm64_L1768_C3")]
    public _shift_e__Struct shift;

    public arm64_extender ext;

    public arm64_op_type type;

    public arm64_svcr_op svcr;

    [NativeTypeName("__AnonymousRecord_arm64_L1775_C3")]
    public _Anonymous2_e__Union Anonymous2;

    [NativeTypeName("uint8_t")]
    public byte access;

    [UnscopedRef]
    public ref arm64_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.reg;
        }
    }

    [UnscopedRef]
    public ref nint imm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.imm;
        }
    }

    [UnscopedRef]
    public ref double fp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.fp;
        }
    }

    [UnscopedRef]
    public ref arm64_op_mem mem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.mem;
        }
    }

    [UnscopedRef]
    public ref arm64_pstate pstate
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.pstate;
        }
    }

    [UnscopedRef]
    public ref arm64_sys_op sys
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.sys;
        }
    }

    [UnscopedRef]
    public ref arm64_prefetch_op prefetch
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.prefetch;
        }
    }

    [UnscopedRef]
    public ref arm64_barrier_op barrier
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.barrier;
        }
    }

    [UnscopedRef]
    public ref arm64_op_sme_index sme_index
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.sme_index;
        }
    }

    public partial struct _shift_e__Struct
    {
        public arm64_shifter type;

        [NativeTypeName("unsigned int")]
        public uint value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous2_e__Union
    {
        [FieldOffset(0)]
        public arm64_reg reg;

        [FieldOffset(0)]
        [NativeTypeName("int64_t")]
        public nint imm;

        [FieldOffset(0)]
        public double fp;

        [FieldOffset(0)]
        public arm64_op_mem mem;

        [FieldOffset(0)]
        public arm64_pstate pstate;

        [FieldOffset(0)]
        public arm64_sys_op sys;

        [FieldOffset(0)]
        public arm64_prefetch_op prefetch;

        [FieldOffset(0)]
        public arm64_barrier_op barrier;

        [FieldOffset(0)]
        public arm64_op_sme_index sme_index;
    }
}
