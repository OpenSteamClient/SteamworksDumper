using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_mips_op
{
    public mips_op_type type;

    [NativeTypeName("__AnonymousRecord_mips_L242_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref mips_reg reg
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
    public ref mips_op_mem mem
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
        public mips_reg reg;

        [FieldOffset(0)]
        [NativeTypeName("int64_t")]
        public nint imm;

        [FieldOffset(0)]
        public mips_op_mem mem;
    }
}
