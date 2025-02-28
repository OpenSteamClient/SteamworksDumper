using System.Runtime.InteropServices;
using System.Text;
using Rosentti.Capstone.Native;

namespace Rosentti.Capstone;

public abstract unsafe class Instruction
{
    internal cs_insn* Pointer { get; }

    protected Instruction(cs_insn* ptr)
    {
        Pointer = ptr;
    }

    public ReadOnlySpan<byte> Bytes
        => AccessPointerSafe()->bytes[..Size];
    
    public nuint Address => AccessPointerSafe()->address;
    public ushort Size => AccessPointerSafe()->size;

    public string Mnemonic
    {
        get
        {
            fixed (sbyte* sbptr = (ReadOnlySpan<sbyte>)(AccessPointerSafe()->mnemonic))
            {
                byte* bptr = (byte*)sbptr;
                //TODO: These can read OOB, should cap to sizeof(field)
                return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(bptr));
            }
            
        }
    }
    
    public string Operands
    {
        get
        {
            fixed (sbyte* sbptr = (ReadOnlySpan<sbyte>)(AccessPointerSafe()->op_str))
            {
                byte* bptr = (byte*)sbptr;
                //TODO: These can read OOB, should cap to sizeof(field)
                return Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(bptr));
            }
        }
    }
    
    /// <summary>
    /// Access pointer or throw <see cref="ObjectDisposedException"/> if null.
    /// </summary>
    /// <returns></returns>
    internal cs_insn* AccessPointerSafe()
    {
        ThrowIfDisposed();
        return Pointer;
    }

    internal cs_detail* AccessDetailPointerSafe()
    {
        var ptr = AccessPointerSafe();
        if (ptr->detail == null)
            throw new InvalidOperationException("Attempted to get details but instruction was disassembled with details off");

        return ptr->detail;
    }

    protected void ThrowIfDisposed()
    {
        if (Pointer != null)
            return;
        
        throw new ObjectDisposedException(nameof(Instruction));
    }

    /// <summary>
    /// Clear caches to recycle this instruction instance's allocated memory. You must override this if you use caching, otherwise <see cref="IteratingDisassembler{TInstruction}"/> will not work.
    /// </summary>
    internal virtual void Clear()
    {
        
    }
}