using System.Collections.Immutable;
using System.Runtime;
using Rosentti.Capstone.Native;

namespace Rosentti.Capstone.X86;

public class X86InstructionDetails
{
    public unsafe X86InstructionDetails(in cs_x86 details)
    {
        var nativeOperands = details.operands[..details.op_count];
        
        // This is not ideal and DPA complains. Optimize...
        var builder = ImmutableArray.CreateBuilder<X86Operand>(nativeOperands.Length);
        for (int i = 0; i < nativeOperands.Length; i++)
        {
            builder.Add(new X86Operand(in nativeOperands[i]));
        }
    
        this.Operands = builder.MoveToImmutable();
    }
    
    public ImmutableArray<X86Operand> Operands { get; }
}