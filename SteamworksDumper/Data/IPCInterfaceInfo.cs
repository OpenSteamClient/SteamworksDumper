namespace SteamworksDumper.Data;

public record IPCInterfaceInfo(string name, byte interfaceid, IEnumerable<IPCFunctionInfo> methods);
