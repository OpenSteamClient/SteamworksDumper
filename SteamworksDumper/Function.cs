using SteamworksDumper.Data;

namespace SteamworksDumper;

public sealed class Function
{
    public readonly int Offset = 0;

    public Function(int offset)
    {
        this.Offset = offset;
    }
        
        
    public FunctionState State = FunctionState.NoData;
    public bool IgnoredFirstPut = false;
    
    public byte CommandCode = 0;
    public byte InterfaceCode = 0;
    public uint FunctionID = 0;
    public List<string> Args = new();
    public uint Fencepost = 0;
    public List<string> Returns = new();

    public int CurrentPush = 0;
    public bool GotLoad1 = false;

    public bool GotJE = false;
    public bool GotMOV = false;
    public long LastLoad = 0;
    
    public string Name = string.Empty;
    public bool BannedInCrossProc = false;

    public override string ToString()
    {
        return $"{State} I{InterfaceCode}::F{FunctionID}::P{Fencepost}";
    }

    public override int GetHashCode()
        => HashCode.Combine(Offset);
}