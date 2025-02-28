using System.Diagnostics;

namespace SteamworksDumper.Utils;

public static class DebuggerEx
{
    public static void BreakIfDebug()
    {
        #if DEBUG
        Debugger.Break();
        #endif
    }
}