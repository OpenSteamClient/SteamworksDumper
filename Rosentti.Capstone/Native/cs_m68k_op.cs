using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_m68k_op
{
    [NativeTypeName("__AnonymousRecord_m68k_L161_C2")]
    public _Anonymous_e__Union Anonymous;

    public m68k_op_mem mem;

    public m68k_op_br_disp br_disp;

    [NativeTypeName("uint32_t")]
    public uint register_bits;

    public m68k_op_type type;

    public m68k_address_mode address_mode;

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
    public ref double dimm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.dimm;
        }
    }

    [UnscopedRef]
    public ref float simm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.simm;
        }
    }

    [UnscopedRef]
    public ref m68k_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

    [UnscopedRef]
    public ref cs_m68k_op_reg_pair reg_pair
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg_pair;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint imm;

        [FieldOffset(0)]
        public double dimm;

        [FieldOffset(0)]
        public float simm;

        [FieldOffset(0)]
        public m68k_reg reg;

        [FieldOffset(0)]
        public cs_m68k_op_reg_pair reg_pair;
    }
}
