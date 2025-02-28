using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rosentti.Capstone.Native;
using Rosentti.Capstone.X86;

namespace Rosentti.Capstone;

public abstract unsafe class CapstoneDisassembler : IDisposable
{
    private UIntPtr handle;
    
    protected CapstoneDisassembler(cs_arch arch, cs_mode mode)
    {
        this.Arch = arch;
        this.Mode = mode;
        fixed (UIntPtr* ptr = &handle)
        {
            CapstoneException.ThrowIfFailed(Methods.cs_open(arch, mode, ptr));
        }
    }
    
    public UIntPtr Handle => handle;
    public cs_arch Arch { get; }
    public cs_mode Mode { get; }
    
    private bool enabledInstructionDetails = false;
    public bool EnableInstructionDetails
    {
        get => enabledInstructionDetails;
        set
        {
            cs_option(cs_opt_type.CS_OPT_DETAIL, value ? cs_opt_value.CS_OPT_ON : cs_opt_value.CS_OPT_OFF);
            enabledInstructionDetails = value;
        }
    }
    
    private bool enabledSkipData = false;
    public bool EnableSkipDataMode 
    {
        get => enabledSkipData;
        set
        {
            cs_option(cs_opt_type.CS_OPT_SKIPDATA, value ? cs_opt_value.CS_OPT_ON : cs_opt_value.CS_OPT_OFF);
            enabledSkipData = value;
        }
    }
    
    public void cs_option(cs_opt_type option, UIntPtr value)
    {
        CapstoneException.ThrowIfFailed(Methods.cs_option(Handle, option, value));
    }

    public void cs_option(cs_opt_type option, cs_opt_value value)
        => cs_option(option, (UIntPtr)value);
    
    public static CapstoneX86Disassembler CreateX86Disassembler(cs_mode mode)
        => new(cs_arch.CS_ARCH_X86, mode);

    public virtual void Dispose()
    {
        fixed (UIntPtr* ptr = &handle)
        {
            // cs_close zeroes handle
            CapstoneException.ThrowIfFailed(Methods.cs_close(ptr));
        }
    }
    
    protected void ThrowIfDisposed()
    {
        if (Handle == 0)
            throw new ObjectDisposedException(nameof(CapstoneDisassembler));
    }
}

public sealed class IteratingDisassembler<TInstruction> : IDisposable where TInstruction : Instruction
{
    /// <summary>
    /// The current instruction.
    /// </summary>
    public TInstruction CurrentInstruction { get; private set; }

    private readonly CapstoneDisassembler<TInstruction> disassembler;
    internal IteratingDisassembler(CapstoneDisassembler<TInstruction> disassembler)
    {
        this.disassembler = disassembler;
        CurrentInstruction = disassembler.AllocateInstruction();
    }


    private bool isDisposed;
    public void Dispose()
    {
        ThrowIfDisposed();
        isDisposed = true;

        disassembler.ReleaseIteratingDisassembler(this);
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(isDisposed, this);
    }
    
    /// <summary>
    /// Iterates over the given code. The output is available at <see cref="CurrentInstruction"/>
    /// </summary>
    /// <param name="code">Code to disassemble.</param>
    /// <param name="offset">The offset to begin disassembling from. This will be updated to the offset to start of the next instruction.</param>
    /// <returns>True if decompiling succeeded, false if it did not.</returns>
    public unsafe bool Iterate(ReadOnlySpan<byte> code, ref UIntPtr offset)
    {
        ThrowIfDisposed();
        
        fixed (byte* bptr = code)
        {
            byte* pCode = bptr;
            UIntPtr size = (UIntPtr)code.Length;
            CurrentInstruction.Clear();
            var success = Methods.cs_disasm_iter(disassembler.Handle, &pCode, &size, (UIntPtr*)Unsafe.AsPointer(ref offset), CurrentInstruction.Pointer);
            if (success != 1)
            {
                return false;
            }
            
            return true;
        }
    }
}

public abstract unsafe class CapstoneDisassembler<TInstruction> : CapstoneDisassembler where TInstruction: Instruction
{
    protected CapstoneDisassembler(cs_arch arch, cs_mode mode) : base(arch, mode)
    {
    }

    /// <summary>
    /// Tracking collection to ensure users free all iterating disassemblers before freeing regular disassembler.
    /// Value does not matter here.
    /// </summary>
    private readonly ConcurrentDictionary<IteratingDisassembler<TInstruction>, object?> iteratingDisassemblers = new();

    public IteratingDisassembler<TInstruction> CreateIteratingDisassembler()
    {
        var iteratingDisassembler = new IteratingDisassembler<TInstruction>(this);
        // This should never fail.
        iteratingDisassemblers.TryAdd(iteratingDisassembler, null);
        return iteratingDisassembler;
    }
    
    internal void ReleaseIteratingDisassembler(IteratingDisassembler<TInstruction> disassembler)
    {
        Methods.cs_free(disassembler.CurrentInstruction.Pointer, 1);
        iteratingDisassemblers.TryRemove(disassembler, out _);
    }
    
    public DisassembleResults<TInstruction> Disassemble(ReadOnlySpan<byte> code, UIntPtr offset)
    {
        UIntPtr size = (UIntPtr)code.Length;
        cs_insn* ptrToInstrs = null;
        UIntPtr numInstrs;
        fixed (byte* bptr = code)
        {
            numInstrs = Methods.cs_disasm(Handle, bptr, size, offset, (UIntPtr)code.Length, &ptrToInstrs);
        }
        
        if (numInstrs == 0 || ptrToInstrs == null)
            throw new Exception("Failed to disassemble.");
            
        return new DisassembleResults<TInstruction>(this, ptrToInstrs, numInstrs);
    }

    internal abstract TInstruction AllocateInstruction(cs_insn* ptr);

    internal TInstruction AllocateInstruction()
        => AllocateInstruction(Methods.cs_malloc(Handle));

    public override void Dispose()
    {
        ThrowIfDisposed();
        if (iteratingDisassemblers.Count > 0) 
            throw new InvalidOperationException("Tried to dispose CapstoneDisassembler, but IteratingDisassemblers were not disposed first.");
        
        base.Dispose();
    }
}