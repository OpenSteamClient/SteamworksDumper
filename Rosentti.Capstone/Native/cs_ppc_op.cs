using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_ppc_op
{
    public ppc_op_type type;

    [NativeTypeName("__AnonymousRecord_ppc_L316_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref ppc_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

    [UnscopedRef]
    public ref nint imm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.imm;
        }
    }

    [UnscopedRef]
    public ref ppc_op_mem mem
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mem;
        }
    }

    [UnscopedRef]
    public ref ppc_op_crx crx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.crx;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public ppc_reg reg;

        [FieldOffset(0)]
        [NativeTypeName("int64_t")]
        public nint imm;

        [FieldOffset(0)]
        public ppc_op_mem mem;

        [FieldOffset(0)]
        public ppc_op_crx crx;
    }
}
