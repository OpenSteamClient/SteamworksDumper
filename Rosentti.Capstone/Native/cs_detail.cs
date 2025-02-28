using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_detail
{
    [NativeTypeName("uint16_t[20]")]
    public _regs_read_e__FixedBuffer regs_read;

    [NativeTypeName("uint8_t")]
    public byte regs_read_count;

    [NativeTypeName("uint16_t[20]")]
    public _regs_write_e__FixedBuffer regs_write;

    [NativeTypeName("uint8_t")]
    public byte regs_write_count;

    [NativeTypeName("uint8_t[8]")]
    public _groups_e__FixedBuffer groups;

    [NativeTypeName("uint8_t")]
    public byte groups_count;

    [NativeTypeName("bool")]
    public byte writeback;

    [NativeTypeName("__AnonymousRecord_capstone_L411_C2")]
    public _Anonymous_e__Union Anonymous;

    [UnscopedRef]
    public ref cs_x86 x86
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.x86;
        }
    }

    [UnscopedRef]
    public ref cs_arm64 arm64
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.arm64;
        }
    }

    [UnscopedRef]
    public ref cs_arm arm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.arm;
        }
    }

    [UnscopedRef]
    public ref cs_m68k m68k
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.m68k;
        }
    }

    [UnscopedRef]
    public ref cs_mips mips
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mips;
        }
    }

    [UnscopedRef]
    public ref cs_ppc ppc
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.ppc;
        }
    }

    [UnscopedRef]
    public ref cs_sparc sparc
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.sparc;
        }
    }

    [UnscopedRef]
    public ref cs_sysz sysz
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.sysz;
        }
    }

    [UnscopedRef]
    public ref cs_xcore xcore
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.xcore;
        }
    }

    [UnscopedRef]
    public ref cs_tms320c64x tms320c64x
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.tms320c64x;
        }
    }

    [UnscopedRef]
    public ref cs_m680x m680x
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.m680x;
        }
    }

    [UnscopedRef]
    public ref cs_evm evm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.evm;
        }
    }

    [UnscopedRef]
    public ref cs_mos65xx mos65xx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.mos65xx;
        }
    }

    [UnscopedRef]
    public ref cs_wasm wasm
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.wasm;
        }
    }

    [UnscopedRef]
    public ref cs_bpf bpf
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.bpf;
        }
    }

    [UnscopedRef]
    public ref cs_riscv riscv
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.riscv;
        }
    }

    [UnscopedRef]
    public ref cs_sh sh
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.sh;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        public cs_x86 x86;

        [FieldOffset(0)]
        public cs_arm64 arm64;

        [FieldOffset(0)]
        public cs_arm arm;

        [FieldOffset(0)]
        public cs_m68k m68k;

        [FieldOffset(0)]
        public cs_mips mips;

        [FieldOffset(0)]
        public cs_ppc ppc;

        [FieldOffset(0)]
        public cs_sparc sparc;

        [FieldOffset(0)]
        public cs_sysz sysz;

        [FieldOffset(0)]
        public cs_xcore xcore;

        [FieldOffset(0)]
        public cs_tms320c64x tms320c64x;

        [FieldOffset(0)]
        public cs_m680x m680x;

        [FieldOffset(0)]
        public cs_evm evm;

        [FieldOffset(0)]
        public cs_mos65xx mos65xx;

        [FieldOffset(0)]
        public cs_wasm wasm;

        [FieldOffset(0)]
        public cs_bpf bpf;

        [FieldOffset(0)]
        public cs_riscv riscv;

        [FieldOffset(0)]
        public cs_sh sh;
    }

    [InlineArray(20)]
    public partial struct _regs_read_e__FixedBuffer
    {
        public ushort e0;
    }

    [InlineArray(20)]
    public partial struct _regs_write_e__FixedBuffer
    {
        public ushort e0;
    }

    [InlineArray(8)]
    public partial struct _groups_e__FixedBuffer
    {
        public byte e0;
    }
}
