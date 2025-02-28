using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct m68k_op_size
{
    public m68k_size_type type;

    [NativeTypeName("__AnonymousRecord_m68k_L203_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref m68k_cpu_size cpu_size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.cpu_size;
        }
    }

    [UnscopedRef]
    public ref m68k_fpu_size fpu_size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.fpu_size;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public m68k_cpu_size cpu_size;

        [FieldOffset(0)]
        public m68k_fpu_size fpu_size;
    }
}
