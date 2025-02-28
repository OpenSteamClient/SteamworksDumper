using Rosentti.Capstone.Native;

namespace Rosentti.Capstone.X86;

public sealed class X86Operand
{
    public X86Operand(in cs_x86_op op)
    {
        Type = op.type;

        switch (Type)
        {
            case x86_op_type.X86_OP_IMM:
                immediate = op.imm;
                return;
            
            case x86_op_type.X86_OP_REG:
                register = op.reg;
                return;
            
            case x86_op_type.X86_OP_MEM:
                memory = op.mem;
                return;
        }
        
        immediate = op.imm;
    }

    public x86_op_type Type { get; }

    private readonly IntPtr immediate;
    public IntPtr Immediate
    {
        get
        {
            if (Type != x86_op_type.X86_OP_IMM)
                throw new InvalidOperationException("Operand is not X86_OP_IMM");
            
            return immediate;
        }
    }
    
    private readonly x86_reg register;
    public x86_reg Register
    {
        get
        {
            if (Type != x86_op_type.X86_OP_REG)
                throw new InvalidOperationException("Operand is not X86_OP_REG");
            
            return register;
        }
    }
    
    private readonly x86_op_mem memory;
    public x86_op_mem Memory
    {
        get
        {
            if (Type != x86_op_type.X86_OP_MEM)
                throw new InvalidOperationException("Operand is not X86_OP_MEM");
            
            return memory;
        }
    }
}