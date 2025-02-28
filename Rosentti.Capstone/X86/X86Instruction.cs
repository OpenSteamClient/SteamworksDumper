using Rosentti.Capstone.Native;

namespace Rosentti.Capstone.X86;

public unsafe class X86Instruction : Instruction
{
    public X86Instruction(cs_insn* ptr) : base(ptr)
    {
    }

    public x86_insn Id => (x86_insn)AccessPointerSafe()->id;
    
    private X86InstructionDetails? detailsCached;

    /// <summary>
    /// The details of this instruction.
    /// </summary>
    public X86InstructionDetails Details
    {
        get
        {
            if (detailsCached != null)
                return detailsCached;

            return detailsCached = new X86InstructionDetails(AccessDetailPointerSafe()->x86);
        }
    }

    /// <summary>
    /// Wipe caches. Call this when the underlying native pointer does not change, but it's data does.
    /// </summary>
    internal override void Clear()
    {
        detailsCached = null;
    }
}