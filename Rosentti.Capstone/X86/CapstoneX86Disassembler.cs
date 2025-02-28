using Rosentti.Capstone.Native;

namespace Rosentti.Capstone.X86;

public class CapstoneX86Disassembler : CapstoneDisassembler<X86Instruction>
{
    public CapstoneX86Disassembler(cs_arch arch, cs_mode mode) : base(arch, mode)
    {
    }

    internal override unsafe X86Instruction AllocateInstruction(cs_insn* ptr)
        => new(ptr);
}