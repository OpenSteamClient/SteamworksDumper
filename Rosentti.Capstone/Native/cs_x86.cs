using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_x86
{
    [NativeTypeName("uint8_t[4]")]
    public _prefix_e__FixedBuffer prefix;

    [NativeTypeName("uint8_t[4]")]
    public _opcode_e__FixedBuffer opcode;

    [NativeTypeName("uint8_t")]
    public byte rex;

    [NativeTypeName("uint8_t")]
    public byte addr_size;

    [NativeTypeName("uint8_t")]
    public byte modrm;

    [NativeTypeName("uint8_t")]
    public byte sib;

    [NativeTypeName("int64_t")]
    public nint disp;

    public x86_reg sib_index;

    [NativeTypeName("int8_t")]
    public sbyte sib_scale;

    public x86_reg sib_base;

    public x86_xop_cc xop_cc;

    public x86_sse_cc sse_cc;

    public x86_avx_cc avx_cc;

    [NativeTypeName("bool")]
    public byte avx_sae;

    public x86_avx_rm avx_rm;

    [NativeTypeName("__AnonymousRecord_x86_L366_C2")]
    public _Anonymous_e__Union Anonymous;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_x86_op[8]")]
    public _operands_e__FixedBuffer operands;

    public cs_x86_encoding encoding;

    [UnscopedRef]
    public ref nuint eflags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.eflags;
        }
    }

    [UnscopedRef]
    public ref nuint fpu_flags
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.fpu_flags;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint eflags;

        [FieldOffset(0)]
        [NativeTypeName("uint64_t")]
        public nuint fpu_flags;
    }

    [InlineArray(4)]
    public partial struct _prefix_e__FixedBuffer
    {
        public byte e0;
    }

    [InlineArray(4)]
    public partial struct _opcode_e__FixedBuffer
    {
        public byte e0;
    }

    [InlineArray(8)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_x86_op e0;
    }
}
