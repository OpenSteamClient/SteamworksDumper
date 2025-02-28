namespace SteamworksDumper.Data;

public record IPCFunctionInfo(string name, uint functionid, uint fencepost, bool blacklistedInCrossProcessIPC, int nativeArgc, IEnumerable<IPCArgumentInfo> args, IEnumerable<IPCArgumentInfo> returns);