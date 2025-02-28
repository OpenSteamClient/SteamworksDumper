using SteamworksDumper.Utils;

namespace SteamworksDumper;

public class ClientInterface
{
    public byte InterfaceID = 0;
    public string InterfaceName = "Unknown";
    public int FoundAt = 0;
    public List<Function> Functions = new();

    public override string ToString()
    {
        return $"(Name: {InterfaceName}, ID: {InterfaceID}, FoundAt: {GhidraUtil.GetOffsetForGhidra(FoundAt)}, Num Functions: {Functions.Count})";
    }
}