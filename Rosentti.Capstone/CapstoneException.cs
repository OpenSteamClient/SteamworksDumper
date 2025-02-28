using Rosentti.Capstone.Native;

namespace Rosentti.Capstone;

public class CapstoneException
{
    public static void ThrowIfFailed(cs_err err)
    {
        switch (err)
        {
            case cs_err.CS_ERR_OK:
                return;
            case cs_err.CS_ERR_MEM:
                throw new OutOfMemoryException("Out-Of-Memory error: cs_open(), cs_disasm(), cs_disasm_iter()");
            case cs_err.CS_ERR_ARCH:
                throw new ArgumentOutOfRangeException("arch", "Unsupported architecture: cs_open()");
            case cs_err.CS_ERR_CSH:
                throw new ArgumentException("Invalid csh argument: cs_close(), cs_errno(), cs_option()");
            case cs_err.CS_ERR_HANDLE:
                throw new ArgumentException("Invalid handle: cs_op_count(), cs_op_index()");
            case cs_err.CS_ERR_MODE:
                throw new ArgumentOutOfRangeException("mode", "Invalid/unsupported mode: cs_open()");
            case cs_err.CS_ERR_OPTION:
                throw new ArgumentOutOfRangeException("option", "Invalid/unsupported option: cs_option()");
            case cs_err.CS_ERR_DETAIL:
                throw new InvalidOperationException("Information is unavailable because detail option is OFF");
            case cs_err.CS_ERR_MEMSETUP:
                throw new ArgumentException("Dynamic memory management uninitialized (see CS_OPT_MEM)");
            case cs_err.CS_ERR_VERSION:
                throw new Exception("Unsupported version (bindings)");
            case cs_err.CS_ERR_DIET:
                throw new InvalidOperationException("Access irrelevant data in \"diet\" engine");
            case cs_err.CS_ERR_SKIPDATA:
                throw new InvalidOperationException("Access irrelevant data for \"data\" instruction in SKIPDATA mode");
            case cs_err.CS_ERR_X86_ATT:
                throw new NotSupportedException("X86 AT&T syntax is unsupported (opt-out at compile time)");
            case cs_err.CS_ERR_X86_INTEL:
                throw new NotSupportedException("X86 Intel syntax is unsupported (opt-out at compile time)");
            case cs_err.CS_ERR_X86_MASM:
                throw new NotSupportedException("X86 Masm syntax is unsupported (opt-out at compile time)");
            default:
                throw new ArgumentOutOfRangeException(nameof(err), err, null);
        }
    }
}