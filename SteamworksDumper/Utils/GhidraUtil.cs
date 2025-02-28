namespace SteamworksDumper.Utils;

public static class GhidraUtil
{
    public static string GetOffsetForGhidra(long positionInText)
    {
        if (positionInText == 0)
            return "0x0";
        
        return $"0x{positionInText + 0x10000:X}";
    }
}