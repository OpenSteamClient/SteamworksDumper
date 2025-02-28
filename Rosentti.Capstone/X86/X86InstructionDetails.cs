using System.Collections.Immutable;
using Rosentti.Capstone.Native;

namespace Rosentti.Capstone.X86;

public class X86InstructionDetails
{
    public X86InstructionDetails(in cs_x86 details)
    {
        var nativeOperands = details.operands[..details.op_count];
        var arrOps = new X86Operand[nativeOperands.Length];
        for (int i = 0; i < nativeOperands.Length; i++)
        {
            arrOps[i] = new X86Operand(in nativeOperands[i]);
        }
        
        this.Operands = arrOps.ToImmutableArray();
    }
    
    public ImmutableArray<X86Operand> Operands { get; }
}