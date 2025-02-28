using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_xcore_op
{
    public xcore_op_type type;

    [NativeTypeName("__AnonymousRecord_xcore_L77_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref xcore_reg reg
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.reg;
        }
    }

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
    public ref xcore_op_mem mem
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
        public xcore_reg reg;

        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int imm;

        [FieldOffset(0)]
        public xcore_op_mem mem;
    }
}
