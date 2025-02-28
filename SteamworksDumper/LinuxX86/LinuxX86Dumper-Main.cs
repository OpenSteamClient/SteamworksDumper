using System.Diagnostics;
using System.Text.RegularExpressions;
using Rosentti.Capstone.Native;
using Rosentti.Capstone.X86;
using SteamworksDumper.Extensions;
using SteamworksDumper.Utils;

namespace SteamworksDumper.LinuxX86;

public partial class LinuxX86Dumper
{
    private const string FAIL_READ_RESULT_CODE_ASSERT_STR = "IPC call to %s::%s failed to read result code.";
    private const string RESULT_CODE_INDICATES_FAILURE_ASSERT_STR = "IPC call to %s::%s returned failure code %d";
    private const string CROSS_PROC_BAN_ASSERT_STR = "Cannot call %s::%s in cross-process pipe!";
    
    private IEnumerable<Elf32_Sym> FindSymbols(string part)
    {
        var list = new List<Elf32_Sym>();
        
        var dynsymSect = this.GetSection(".dynsym").As<byte, Elf32_Sym>();
        var dynstrSection = this.GetSection(".dynstr");
        for (int i = 0; i < dynsymSect.Length; i++)
        {
            int startAddr = (int)dynsymSect[i].st_name;
            var s = dynstrSection[startAddr..].ReadString();
            if (s.Contains(part))
            {
                list.Add(dynsymSect[i]);
            }
        }

        return list;
    }
    
    private IEnumerable<long> GetVTTypes()
    {
        List<long> t_out = new();
        List<Elf32_Sym> tis = FindSymbols("_class_type_infoE").ToList();
        foreach (var it in tis)
        {
            var refs = GetRefsToSymbol(it.st_value);
            t_out.AddRange(refs);
        }

        return t_out;
    }
    
    [GeneratedRegex("(IClient|IRegistry)[A-Za-z]+Map", RegexOptions.CultureInvariant)]
    private static partial Regex MatchingClassNameRegex();
    
    public IEnumerable<ClientInterface> DumpAll()
    {
        var dumpedInterfaces = new List<ClientInterface>();
        
        var interfaces = GetVTTypes().ToList();
        for (int i = 0; i < interfaces.Count; i++)
        {
            int it = (int)interfaces[i];
            int strOffset = programImage.AsSpan()[(it + 4)..].Read<byte, int>();
            var name = programImage.AsSpan()[strOffset..].ReadString();

            if (name.Contains("CAdapter"))
            {
                // Dump adapters?
                Console.WriteLine("Adapter: " + name.Substring(2).Replace("CAdapter", "") + " at " + GhidraUtil.GetOffsetForGhidra(it));
            }
            
            if (MatchingClassNameRegex().IsMatch(name))
            {
                foreach (var constOffset in consts)
                {
                    var val = programImage.AsSpan()[(constOffset - 4)..].Read<byte, int>();
                    
                    if (val == it)
                    {
                        var thisInterface = new ClientInterface();
                        thisInterface.FoundAt = constOffset;
                
                        // Get rid of name mangling artifacts (14 at the start of name), and Map from the end of the string
                        thisInterface.InterfaceName = name.Substring(2, name.Length - 5);
                        dumpedInterfaces.Add(thisInterface);

                        int vtIdx = 0;
                
                        Console.WriteLine("Interface GPtr: " + GhidraUtil.GetOffsetForGhidra(constOffset));
                        ReadOnlySpan<int> vtPtrs = programImage.AsSpan()[constOffset..].As<byte, int>();
                        while (true)
                        {
                            int vtPtr = vtPtrs[vtIdx];
                            vtIdx++;
                            if (vtPtr == 0)
                                break;

                            if (IsOffsetInText(vtPtr))
                            {
                                thisInterface.Functions.Add(DisassembleIPCFunction(vtPtr, vtIdx, thisInterface.InterfaceName));
                            }
                            else
                            {
                                Console.WriteLine("Non-text VT pointer " + GhidraUtil.GetOffsetForGhidra(vtPtr));
                                DebuggerEx.BreakIfDebug();
                            }
                        }

                        //TODO: We could increase robustness by counting the amount same interface codes and using the most common one
                        thisInterface.InterfaceID = thisInterface.Functions.FirstOrDefault(a => a.InterfaceCode != 0)?.InterfaceCode ?? 0;
                    }
                }
            }
        }

        return dumpedInterfaces;
    }
    
    private Function DisassembleIPCFunction(int offset, int vtIdx, string interfaceName)
    {
        Console.WriteLine("Function GPtr: " + GhidraUtil.GetOffsetForGhidra(offset));
        
        // Position in text (IP)
        long positionInText = offset;
        
        var length = functionLengths[offset];
        
        Function currentFunction = new Function(offset);
        List<string> diagnosticEvents = new();
        
        var disasmData = programImage[offset..(offset+length)];

        using var results = disassembler.Disassemble(disasmData, 0);
        X86Instruction? lastInstruction = null;
        foreach (var instr in results.Instructions)
        {
            positionInText += instr.Bytes.Length;
            
            #if DEBUG
            Console.WriteLine("Ghidra pos: " + GhidraUtil.GetOffsetForGhidra(positionInText));
            #endif
            
            switch (instr.Id)
            {
                case x86_insn.X86_INS_CALL:
                    if (instr.Details.Operands[0].Type != x86_op_type.X86_OP_IMM)
                        break;

                    unchecked
                    {
                        int absoluteCallPosition = GetAbsoluteCallPosition((int)positionInText, instr);
                        
#if DEBUG
                        Console.WriteLine("Immediate: " + GhidraUtil.GetOffsetForGhidra(absoluteCallPosition));
#endif
                        if (absoluteCallPosition == constants.GetBytesFnOffset)
                        {
                            if (currentFunction.GotLoad1 && currentFunction.State == FunctionState.GotIPCSend)
                            {
                                currentFunction.State = FunctionState.GotIPCResultCode;
                                currentFunction.GotLoad1 = false;
                            }
                        }
                        else
                        {
                            currentFunction.GotLoad1 = false;
                        }

                        if (absoluteCallPosition == constants.CUtlBufferCtorOffset)
                        {
                            currentFunction.State = FunctionState.UtlBufferInitialized;
                        } else if (absoluteCallPosition == constants.SendSerializedFnOffset)
                        {
                            if (currentFunction.State >= FunctionState.GotIPCSend)
                            {
                                diagnosticEvents.Add($"Got a SendSerialized() but we already had one before ({GhidraUtil.GetOffsetForGhidra(positionInText)})");
                                DebuggerEx.BreakIfDebug();
                            }
                            
                            diagnosticEvents.Add($"SendSerialized ({GhidraUtil.GetOffsetForGhidra(positionInText)})");
                            currentFunction.State = FunctionState.GotIPCSend;
                        } else if (absoluteCallPosition == constants.IPCClientFreeFuncCallReturnBuffer && currentFunction.State == FunctionState.InReturnDeserialization)
                        {
                            currentFunction.State = FunctionState.EndDumping;
                        }

                        if (currentFunction.State == FunctionState.GotFunctionID)
                        {
                            // We need to ignore first put, as it's the function ID
                            if (currentFunction.IgnoredFirstPut)
                            {
                                var arg = InstructionToArgOrReturnStr(absoluteCallPosition);
                                if (arg != null)
                                {
                                    currentFunction.Args.Add(arg);
                                }
                            }
                            else
                            {
                                currentFunction.IgnoredFirstPut = true;
                            }
                            
                        } else if (currentFunction.State == FunctionState.InReturnDeserialization)
                        {
                            var arg = InstructionToArgOrReturnStr(absoluteCallPosition);
                            if (arg != null)
                            {
                                currentFunction.Returns.Add(arg);
                            }
                        }
                        
                        // if (immediate == PutBytesFnOffset)
                        //     diagnosticEvents.Add("PutBytes");
                        //
                        // if (immediate == PutSingleByteFnOffset)
                        //     diagnosticEvents.Add("PutSingleByte");
                        //
                        // if (immediate == GetBytesFnOffset)
                        //     diagnosticEvents.Add("GetBytes");
                        
                    }
                    break;
                
                case x86_insn.X86_INS_LEA:
                    if (instr.Details.Operands[0].Type != x86_op_type.X86_OP_REG || 
                        instr.Details.Operands[1].Type != x86_op_type.X86_OP_MEM || 
                        instr.Details.Operands[1].Memory.index != x86_reg.X86_REG_INVALID ||
                        instr.Details.Operands[1].Memory.segment != x86_reg.X86_REG_INVALID)
                        break;

                    if (string.IsNullOrEmpty(currentFunction.Name))
                    {
                        int disp;
                        unchecked
                        {
                            disp = (int)(instr.Details.Operands[1].Memory.disp * instr.Details.Operands[1].Memory.scale);
                            disp = (int)(gotOffset + disp);
                        }

                        if (IsOffsetInData(disp))
                        {
                            var possibleName = programImage.AsSpan()[disp..].ReadString();
                            if (possibleName != interfaceName && !possibleName.Any(char.IsControl))
                            {
                                currentFunction.Name = possibleName;
                                Console.WriteLine($"Found name {currentFunction.Name}");
                            }
                        }
                        else
                        {
#if DEBUG
                            Console.WriteLine("Non-data offset " + GhidraUtil.GetOffsetForGhidra(disp));
#endif
                            DebuggerEx.BreakIfDebug();
                        }
                    }
                    
                    break;
                
                case x86_insn.X86_INS_JE:
                    if (currentFunction.State == FunctionState.GotIPCResultCode)
                    {
                        currentFunction.GotJE = true;
                    }
                    break;
                
                case x86_insn.X86_INS_TEST:
                    if (currentFunction.GotJE && currentFunction.GotMOV && currentFunction.State == FunctionState.GotIPCResultCode)
                    {
                        currentFunction.State = FunctionState.InReturnDeserialization;
                    } else if (currentFunction.State == FunctionState.InReturnDeserialization)
                    {
                        if (lastInstruction?.Id == x86_insn.X86_INS_ADD && 
                            lastInstruction.Details.Operands.Length == 2 && 
                            lastInstruction.Details.Operands[1].Type == x86_op_type.X86_OP_IMM && 
                            lastInstruction.Details.Operands[1].Immediate == 0x10)
                        {
                            currentFunction.State = FunctionState.EndDumping;
                        }
                    }
                    
                    break;
                
                case x86_insn.X86_INS_MOV:
                    if (currentFunction.GotJE && currentFunction.State == FunctionState.GotIPCResultCode)
                    {
                        currentFunction.GotMOV = true;
                    }
                    
                    if (instr.Details.Operands[0].Type != x86_op_type.X86_OP_MEM ||
                        instr.Details.Operands[0].Memory.@base != x86_reg.X86_REG_EBP ||
                        instr.Details.Operands[1].Type != x86_op_type.X86_OP_IMM)
                        break;

                    var imm2 = (uint)instr.Details.Operands[1].Immediate;
                    if (currentFunction.State == FunctionState.GotIPCInterfaceCode)
                    {
                        // This can't be real.
                        if (imm2 < 10000)
                            break;
                        
                        currentFunction.FunctionID = imm2;
                        currentFunction.State = FunctionState.GotFunctionID;
                    } else if (currentFunction.State == FunctionState.GotFunctionID)
                    {
                        if (imm2 == 0)
                        {
                            diagnosticEvents.Add($"Got a false fencepost at {GhidraUtil.GetOffsetForGhidra(positionInText)} ({GhidraUtil.GetOffsetForGhidra(currentFunction.Offset)})");
                        }
                        
                        // This can't be real.
                        if (imm2 < 10000)
                            break;
                        
                        // Fenceposts are also always greater than the function id.
                        if (imm2 < currentFunction.FunctionID)
                            break;
                        
                        currentFunction.Fencepost = imm2;
                        currentFunction.State = FunctionState.GotFencepost;
                    }


                    // Determine the functionid and fencepost of the function, as well as what state we're in
                    
                    break;
                
                case x86_insn.X86_INS_PUSH:
                    if (instr.Details.Operands[0].Type == x86_op_type.X86_OP_IMM)
                    {
                        if (instr.Bytes.Length == 2)
                        {
                            var imm = instr.Details.Operands[0].Immediate;
                            currentFunction.LastLoad = imm;

                            if (imm >= byte.MaxValue)
                                break;

                            if (currentFunction.State < FunctionState.GotIPCCommandCode)
                            {
                                // PutSingleByte(buf, k_EInterfaceCall);
                                if (imm != 1)
                                    break;
                                
                                currentFunction.CommandCode = (byte)imm;
                                currentFunction.State = FunctionState.GotIPCCommandCode;
                            } else if (currentFunction.State == FunctionState.GotIPCCommandCode)
                            {
                                if (imm > 64)
                                    diagnosticEvents.Add($"WARNING: Crazy interface ID ({imm})");

                                // This is also not OK.
                                if (imm < 1)
                                {
                                    DebuggerEx.BreakIfDebug();
                                    break;
                                }
                                
                                currentFunction.InterfaceCode = (byte)imm;
                                currentFunction.State = FunctionState.GotIPCInterfaceCode;
                            } else if (currentFunction.State == FunctionState.GotIPCSend)
                            {
                                // GetBytes(&retCode, 1);
                                if (imm != 1)
                                    break;
                                
                                // This one might or might not be for a GetBytes call immediately after the send, which would indicate it's in result code deserialization
                                currentFunction.GotLoad1 = true;
                            }
                        }
                    }
                    
                    break;
            }
            
            lastInstruction = instr;
            //
            // currentFunction.OnInstruction(this, instr);
            //
            // if (currentFunction.PossiblyIPC && !ipcSerializers.Contains(currentFunction))
            //     ipcSerializers.Add(currentFunction);
        }
        
        // We're out of bytes, so we must be done.
        if (currentFunction.Args.Any(a =>
                a.Contains("unknown")) || currentFunction.Returns.Any(a => a.Contains("unknown")))
        {
            DebuggerEx.BreakIfDebug();
        }

        if (string.IsNullOrEmpty(currentFunction.Name))
        {
            Console.WriteLine("Missing name for " + GhidraUtil.GetOffsetForGhidra(currentFunction.Offset));
            currentFunction.Name = $"Unknown_{vtIdx}";
            //DebuggerEx.BreakIfDebug();
        }
        
        return currentFunction;
        
        string? InstructionToArgOrReturnStr(int absoluteCallPosition, bool didIdentify = false)
        {
            if (absoluteCallPosition == constants.PutBytesFnOffset || absoluteCallPosition == constants.GetBytesFnOffset || absoluteCallPosition == constants.GetBytesFn2Offset)
            {
                // It's probably a boolean in this case, mark it as such
                if (currentFunction.LastLoad == 1 && currentFunction.Name.StartsWith("B") || currentFunction.Name.StartsWith("Is"))
                    return "boolean";
                
                return $"bytes{currentFunction.LastLoad}";
            } else if (absoluteCallPosition == constants.PutSingleByteFnOffset || absoluteCallPosition == constants.GetSingleByteFnOffset)
            {
                // It's probably a boolean in this case, mark it as such
                if (currentFunction.Name.StartsWith("B") || currentFunction.Name.StartsWith("Is"))
                    return "boolean";
                
                return "bytes1";
            } else if (absoluteCallPosition == constants.PutUInt64Offset || absoluteCallPosition == constants.GetUInt64FnOffset)
            {
                return "uint64";
            } else if (absoluteCallPosition == PutStringOffset || absoluteCallPosition == PutString2Offset || absoluteCallPosition == GetStringOffset)
            {
                return "string";
            } else if (absoluteCallPosition == PutUtlBufferOffset || absoluteCallPosition == GetUtlBufferOffset)
            {
                return "utlbuf";
            } else if (absoluteCallPosition == AssertInCrossProcessOffset)
            {
                currentFunction.BannedInCrossProc = true;
                return null;
            } else if (absoluteCallPosition == AssertResultCodeIndicatesFailureOffset || absoluteCallPosition == AssertFailedReadResultCodeOffset)
            {
                return null;
            } else if (absoluteCallPosition == GetProtobufOffset || absoluteCallPosition == constants.PutProtobufFnOffset)
            {
                return "protobuf";
            } else if (absoluteCallPosition == constants.PutParamStringArrayFnOffset)
            {
                return "paramstringarray";
            } else if (absoluteCallPosition == constants.PutSNIdentityFnOffset)
            {
                return "steamnetworkingidentity";
            } else if (absoluteCallPosition == GetStringPtrOffset)
            {
                return "pstring";
            }

            if (!didIdentify)
            {
                IdentifyCalledFunction(absoluteCallPosition);
                return InstructionToArgOrReturnStr(absoluteCallPosition, true);
            }
            
            return $"unknown({GhidraUtil.GetOffsetForGhidra(absoluteCallPosition)})";
        }
    }
    
    /// <summary>
    /// Capstone(.NET) provides fake info. Use this to get the absolute call position instead of using operand 0 immediate.
    /// </summary>
    /// <param name="instr"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private int GetAbsoluteCallPosition(int positionInText, X86Instruction instr)
    {
        if (instr.Id != x86_insn.X86_INS_CALL)
            throw new ArgumentException("Instruction must be a CALL", nameof(instr));

        if (instr.Bytes[0] == 0xE8)
        {
            // Capstone(.NET) is not to be trusted. Don't use instr.Details.Operands[0].Immediate, as it's offset by some strange values
            long manual = BitConverter.ToUInt32(instr.Bytes[1..]);
                            
            // Relative jump
            var absoluteCallPosition = positionInText + (int)manual;
            Trace.Assert(absoluteCallPosition > 0);
            return absoluteCallPosition;
        } else if (instr.Bytes[0] == 0xFF)
        {
            // Register calls. Can't do anything here
            return 0;
        }
        else
        {
            throw new Exception($"Unsupported calltype {instr.Bytes[0]}");
        }
    }

    public int PutStringOffset { get; private set; } = 0;
    
    // This method is instruction-by-instruction identical to PutString.
    public int PutString2Offset { get; private set; } = 0;
    public int PutUtlBufferOffset { get; private set; } = 0;
    
    
    public int GetStringOffset { get; private set; } = 0;
    public int GetStringPtrOffset { get; private set; }
    public int GetUtlBufferOffset { get; private set; } = 0;
    public int GetProtobufOffset { get; private set; } = 0;

    public int AssertInCrossProcessOffset { get; private set; } = 0;
    public int AssertFailedReadResultCodeOffset { get; private set; } = 0;
    public int AssertResultCodeIndicatesFailureOffset { get; private set; } = 0;
    
    
    private readonly HashSet<int> processedFunctions = new();
    
    /// <summary>
    /// Some functions can't be scanned via signature.
    /// They get discovered here.
    /// </summary>
    /// <param name="functionOffset"></param>
    private void IdentifyCalledFunction(int functionOffset)
    {
        // Skip functions if they exist already.
        if (!processedFunctions.Add(functionOffset))
            return;
        
        // Position in text (IP)
        long positionInText = functionOffset;
        
        var length = functionLengths[functionOffset];
        var disasmData = programImage[functionOffset..(functionOffset+length)];

        using var results = disassembler.Disassemble(disasmData, 0);
        
        bool gotTest = false;
        bool gotJE = false;
        bool gotGetSingleByte = false;
        bool gotPutBytesCall = false;
        int numUnmatchedCalls = 0;
        
        foreach (var instr in results.Instructions)
        {
            positionInText += instr.Bytes.Length;
            
#if DEBUG
            Console.WriteLine("Ghidra pos: " + GhidraUtil.GetOffsetForGhidra(positionInText));
#endif
            
            switch (instr.Id)
            {
                case x86_insn.X86_INS_LEA:
                    if (instr.Details.Operands[0].Type != x86_op_type.X86_OP_REG || 
                        instr.Details.Operands[1].Type != x86_op_type.X86_OP_MEM || 
                        instr.Details.Operands[1].Memory.index != x86_reg.X86_REG_INVALID ||
                        instr.Details.Operands[1].Memory.segment != x86_reg.X86_REG_INVALID)
                        break;

                    if (AssertInCrossProcessOffset == 0 || AssertResultCodeIndicatesFailureOffset == 0 || AssertFailedReadResultCodeOffset == 0)
                    {
                        int disp;
                        unchecked
                        {
                            disp = (int)(instr.Details.Operands[1].Memory.disp * instr.Details.Operands[1].Memory.scale);
                            disp = (int)(gotOffset + disp);
                        }

                        if (IsOffsetInData(disp))
                        {
                            var assertStr = programImage.AsSpan()[disp..].ReadString();
                            Console.WriteLine($"Found string {assertStr}");

                            if (assertStr == CROSS_PROC_BAN_ASSERT_STR)
                            {
                                if (AssertInCrossProcessOffset == 0)
                                {
                                    AssertInCrossProcessOffset = functionOffset;
                                    return;
                                }
                            } else if (assertStr == RESULT_CODE_INDICATES_FAILURE_ASSERT_STR)
                            {
                                if (AssertResultCodeIndicatesFailureOffset == 0)
                                {
                                    AssertResultCodeIndicatesFailureOffset = functionOffset;
                                    return;
                                }
                            } else if (assertStr == FAIL_READ_RESULT_CODE_ASSERT_STR)
                            {
                                if (AssertFailedReadResultCodeOffset == 0)
                                {
                                    AssertFailedReadResultCodeOffset = functionOffset;
                                    return;
                                }
                            }
                        } 
                        else
                        {
                            #if DEBUG
                            Console.WriteLine("Non-data offset " + GhidraUtil.GetOffsetForGhidra(disp));
                            #endif
                            DebuggerEx.BreakIfDebug();
                        }
                    }
                    
                    break;
                
                case x86_insn.X86_INS_TEST:
                    gotTest = true;
                    break;
                
                case x86_insn.X86_INS_JE:
                    if (gotTest)
                    {
                        gotJE = true;
                    }
                    
                    break;
                
                case x86_insn.X86_INS_JNE:
                    if (gotGetSingleByte && gotTest)
                    {
                        if (GetStringOffset == 0)
                        {
                            Console.WriteLine("Found CUtlBuffer::GetString at " + GhidraUtil.GetOffsetForGhidra(functionOffset));
                            GetStringOffset = functionOffset;
                            return;
                        } else if (GetStringPtrOffset == 0)
                        {
                            Console.WriteLine("Found CUtlBuffer::GetStringPtr at " + GhidraUtil.GetOffsetForGhidra(functionOffset));
                            GetStringPtrOffset = functionOffset;
                            return;
                        }
                    }
                    break;
                
                case x86_insn.X86_INS_CALL:
                    var callPos = GetAbsoluteCallPosition((int)positionInText, instr);

                    if (callPos == constants.GetSingleByteFnOffset)
                    {
                        gotGetSingleByte = true;
                        break;
                    } else if (callPos == constants.PutBytesFnOffset)
                    {
                        gotPutBytesCall = true;
                        break;
                    }

                    if (gotTest && gotJE)
                    {
                        if (PutStringOffset == 0)
                        {
                            // Normally we could simply use the imports and see if we're calling strlen.
                            // Unfortunately there's some really strange finagling of the imports, so it's very unclear how we could map abstract calls to actual imports
                            Console.WriteLine("Found CUtlBuffer::PutString at " + GhidraUtil.GetOffsetForGhidra(functionOffset));
                            PutStringOffset = functionOffset;
                            return;
                        } else if (PutString2Offset == 0)
                        {
                            Console.WriteLine("Found CUtlBuffer::PutString2 at " + GhidraUtil.GetOffsetForGhidra(functionOffset));
                            PutString2Offset = functionOffset;
                            return;
                        }
                    }

                    numUnmatchedCalls++;
                    break;
            }
        }

        if (numUnmatchedCalls == 3 && gotPutBytesCall && GetUtlBufferOffset == 0)
        {
            GetUtlBufferOffset = functionOffset;
            return;
        }
        
        // PutUtlBuffer usually comes before GetUtlBuffer, but let's not count on it
        if (numUnmatchedCalls == 2 && PutUtlBufferOffset == 0 && gotPutBytesCall)
        {
            PutUtlBufferOffset = functionOffset;
            return;
        }

        if (numUnmatchedCalls == 4 && !gotPutBytesCall && !gotTest && !gotJE && !gotGetSingleByte && GetProtobufOffset == 0)
        {
            // This is (most likely) PutProtobuf. This is not 100% foolproof however
            GetProtobufOffset = functionOffset;
            return;
        }
    }
}