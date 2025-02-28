using Rosentti.Capstone.Native;

namespace Rosentti.Capstone;

public abstract unsafe class DisassembleResults : IDisposable
{
    private cs_insn* allocPtr;
    private nuint allocLen;

    protected DisassembleResults(cs_insn* ptr, nuint len)
    {
        this.allocPtr = ptr;
        this.allocLen = len;
    }
    
    public virtual void Dispose()
    {
        Methods.cs_free(allocPtr, allocLen);
        allocPtr = null;
    }
}

public sealed unsafe class DisassembleResults<TInstruction> : DisassembleResults where TInstruction: Instruction
{
    public TInstruction[] Instructions;

    public DisassembleResults(CapstoneDisassembler<TInstruction> disassembler, cs_insn* ptr, nuint len) : base(ptr, len)
    {
        int iNumInstrs;
        checked
        {
            iNumInstrs = (int)len;
        }
        
        Instructions = new TInstruction[iNumInstrs];
        for (int i = 0; i < iNumInstrs; i++)
        {
            var targetPtr = &ptr[i];
            Instructions[i] = disassembler.AllocateInstruction(targetPtr);
        }
    }

    public override void Dispose()
    {
        Instructions = [];
        base.Dispose();
    }
}