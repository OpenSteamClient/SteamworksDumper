using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_sysz_op
{
    public sysz_op_type type;

    [NativeTypeName("__AnonymousRecord_systemz_L186_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref sysz_reg reg
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
    public ref sysz_op_mem mem
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
        public sysz_reg reg;

        [FieldOffset(0)]
        [NativeTypeName("int64_t")]
        public nint imm;

        [FieldOffset(0)]
        public sysz_op_mem mem;
    }
}
