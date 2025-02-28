using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_tms320c64x_op
{
    public tms320c64x_op_type type;

    [NativeTypeName("__AnonymousRecord_tms320c64x_L57_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref uint reg
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
    public ref tms320c64x_op_mem mem
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
        [NativeTypeName("unsigned int")]
        public uint reg;

        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int imm;

        [FieldOffset(0)]
        public tms320c64x_op_mem mem;
    }
}
