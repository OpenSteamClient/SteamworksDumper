using SteamworksDumper.Interface;
using SteamworksDumper.Utils;

namespace SteamworksDumper.LinuxX86;

public class LinuxX86Constants : IConstants
{
    public long CUtlBufferCtorOffset { get; private set; }
    public long SendSerializedFnOffset { get; private set; }
    public long IPCClientFreeFuncCallReturnBuffer { get; private set; }
    public long PutBytesFnOffset { get; private set; }
    public long PutSingleByteFnOffset { get; private set; }
    public long PutUInt64Offset { get; private set; }
    public long GetBytesFnOffset { get; private set; }
    public long GetBytesFn2Offset { get; }
    public long GetUInt64FnOffset { get; }
    public long GetSingleByteFnOffset { get; }
    public long PutSNIdentityFnOffset { get; }
    public long PutProtobufFnOffset { get; }
    public long PutParamStringArrayFnOffset { get; }
    
    public long StrlenReloc { get; }
    
    public LinuxX86Constants(IDumper dumper)
    {
        StrlenReloc = dumper.GetImportRelocByName("strlen");
        Console.WriteLine($"strlen import at {GhidraUtil.GetOffsetForGhidra(StrlenReloc)}");
        
        IPCClientFreeFuncCallReturnBuffer = dumper.FindSignature("CIPCClient::FreeFuncCallReturnBuffer", true,
            "\x55\x57\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x85\xFF\x74\x00\x83\xEC\x00\x8B",
            "xxxxx????xx????xx?x???xxx?xx?x");
        
        CUtlBufferCtorOffset =
            dumper.FindSignature("CUtlBufferCtor", true,
                "\x55\x89\xE5\x57\xE8\x00\x00\x00\x00\x81\xC7\x00\x00\x00\x00\x56\x53\x83\xEC\x00\x8B\x00\x00\x8B\x00\x00\x8B\x00\x00\x85\xC0", "xxxxx????xx????xxxx?x??x??x??xx");
        
        SendSerializedFnOffset = dumper.FindSignature("SendSerialized", true,
            "\x55\x89\xE5\x57\x56\xE8\x00\x00\x00\x00\x81\xC6\x00\x00\x00\x00\x53\x81\xEC\x00\x00\x00\x00\x8B\x45\x08\x89\x85\x00\x00\x00\x00\x8B\x45\x10\x8B\xBE\x00\x00\x00\x00\x89\x85\x00\x00\x00\x00",
            "xxxxxx????xx????xxx????xxxxx????xxxxx????xx????");

        PutBytesFnOffset =
            dumper.FindSignature("CUtlBuffer::PutBytes", true,
                "\x55\x57\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x85\xFF\x7F",
                "xxxxx????xx????xx?x???x???x???xxx");

        PutSingleByteFnOffset =
            dumper.FindSignature("CUtlBuffer::PutByte", true, "\xE8\x00\x00\x00\x00\x81\xC2\x00\x00\x00\x00\x57\x56\x53\x83\xEC\x00\x65",
                "x????xx????xxxxx?x");

        PutUInt64Offset =
            dumper.FindSignature("CUtlBuffer::PutUInt64", false,
                "\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\xF3\x00\x00\x00\x00\x00\x00\x0F\x00\x00\x00\x00\x6A",
                "xx????xx????xx?x??????x????x");

        // One of these GetBytesFn is likely PeekBytes, but it doesn't matter for this program.
        GetBytesFnOffset =
            dumper.FindSignature("CUtlBuffer::GetBytes", true,
                "\x55\x31\xC0\x57\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x85",
                "xxxxxxx????xx????xx?x???x???x");

        GetBytesFn2Offset = dumper.FindSignature("CUtlBuffer::GetBytes2", false,
            "\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x8B\x00\x00\x2B\x00\x00\x39",
            "xxx????xx????xx?x???x???x???x??x??x");

        GetUInt64FnOffset = dumper.FindSignature("CUtlBuffer::GetUInt64", false,
            "\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x8B\x00\x00\x2B",
            "xxx????xx????xx?x???x???x??x");
        
        // This might also be peekbyte
        GetSingleByteFnOffset = dumper.FindSignature("CUtlBuffer::GetByte", false,
            "\xE8\x00\x00\x00\x00\x05\x6F\x00\x00\x00\x53\x83\xEC\x00\x8B\x00\x00\x00\x00\x43", "x????xx???xxx?x????x");

        // There's probably a CIPCBuffer of some kind, this makes no sense in CUtlBuffer. But again, we don't care about the details that much.
        PutSNIdentityFnOffset =
            dumper.FindSignature("CUtlBuffer::PutSteamNetworkingIdentity", false,
                "\x57\x56\x53\x8B\x00\x00\x00\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x8B\x00\x00\x00\x85\xFF\x74\x00\x83\xEC\x00\x68",
                "xxxx???x????xx????x???xxx?xx?x");
        
        PutProtobufFnOffset = dumper.FindSignature("CUtlBuffer::PutProtobuf", false,
            "\x55\x57\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x8B\x00\x00\x00\x8B\x00\x00\x8D\x00\x00\x00\x00\x00\x8B\x00\x00\x39\xD0\x75\x00\x8B",
            "xxxxx????xx????xx?x???x???x??x?????x??xxx?x");

        PutParamStringArrayFnOffset = dumper.FindSignature("CUtlBuffer::PutParamStringArray", false,
            "\x55\x57\x56\x53\xE8\x00\x00\x00\x00\x81\xC3\x00\x00\x00\x00\x83\xEC\x00\x8B\x00\x00\x00\x85\xED\x74\x00\x8B",
            "xxxxx????xx????xx?x???xxx?x");
    }
}