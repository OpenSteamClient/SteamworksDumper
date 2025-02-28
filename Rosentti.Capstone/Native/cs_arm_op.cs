using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_arm_op
{
    public int vector_index;

    [NativeTypeName("__AnonymousRecord_arm_L410_C2")]
    public _shift_e__Struct shift;

    public arm_op_type type;

    [NativeTypeName("__AnonymousRecord_arm_L417_C2")]
    public _Anonymous2_e__Union Anonymous2;

    [NativeTypeName("bool")]
    public byte subtracted;

    [NativeTypeName("uint8_t")]
    public byte access;

    [NativeTypeName("int8_t")]
    public sbyte neon_lane;

    [UnscopedRef]
    public ref int reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.reg;
        }
    }

    [UnscopedRef]
    public ref int imm
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
    public ref arm_op_mem mem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.mem;
        }
    }

    [UnscopedRef]
    public ref arm_setend_type setend
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous2.setend;
        }
    }

    public partial struct _shift_e__Struct
    {
        public arm_shifter type;

        [NativeTypeName("unsigned int")]
        public uint value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous2_e__Union
    {
        [FieldOffset(0)]
        public int reg;

        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int imm;

        [FieldOffset(0)]
        public double fp;

        [FieldOffset(0)]
        public arm_op_mem mem;

        [FieldOffset(0)]
        public arm_setend_type setend;
    }
}
