using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_sh_op
{
    public sh_op_type type;

    [NativeTypeName("__AnonymousRecord_sh_L256_C2")]
    public _Anonymous_e__Union Anonymous;

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
    public ref sh_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

    [UnscopedRef]
    public ref sh_op_mem mem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mem;
        }
    }

    [UnscopedRef]
    public ref sh_op_dsp dsp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.dsp;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint imm;

        [FieldOffset(0)]
        public sh_reg reg;

        [FieldOffset(0)]
        public sh_op_mem mem;

        [FieldOffset(0)]
        public sh_op_dsp dsp;
    }
}
