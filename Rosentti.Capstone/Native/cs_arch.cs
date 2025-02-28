namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum cs_arch : uint
{
    CS_ARCH_ARM = 0,
    CS_ARCH_ARM64,
    CS_ARCH_MIPS,
    CS_ARCH_X86,
    CS_ARCH_PPC,
    CS_ARCH_SPARC,
    CS_ARCH_SYSZ,
    CS_ARCH_XCORE,
    CS_ARCH_M68K,
    CS_ARCH_TMS320C64X,
    CS_ARCH_M680X,
    CS_ARCH_EVM,
    CS_ARCH_MOS65XX,
    CS_ARCH_WASM,
    CS_ARCH_BPF,
    CS_ARCH_RISCV,
    CS_ARCH_SH,
    CS_ARCH_TRICORE,
    CS_ARCH_MAX,
    CS_ARCH_ALL = 0xFFFF,
}
