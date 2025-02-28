using System.Text.Json;
using SteamworksDumper.LinuxX86;

namespace SteamworksDumper.Standalone;

public static class Program
{
    public static void Main(string[] args)
    {
        void PrintUsage()
        {
            Console.WriteLine("Usage: SteamworksDumper.Standalone [input steamclient.so path] [output directory name]");
        }
        
        if (args.Length < 2)
        {
            PrintUsage();
            return;
        }
        
        using var dumper =
            new LinuxX86Dumper(File.Open(args[0], FileMode.Open));

        string basePath;
        if (Path.IsPathRooted(args[1]))
        {
            basePath = args[1];
        }
        else
        {
            basePath = Path.Combine(Directory.GetCurrentDirectory(), "output");
        }
        
        Directory.CreateDirectory(basePath);
        
        var results = dumper.DumpAll();
        
        foreach (var iface in results)
        {
            var jsonIface = new OldJSONFormat.ClientInterface()
            {
                Name = iface.InterfaceName,
                Functions = new(iface.Functions.Count)
            };

            foreach (var func in iface.Functions)
            {
                var jsonFunc = new OldJSONFormat.ClientFunction
                {
                    Name = func.Name,
                    FunctionID = func.FunctionID.ToString(),
                    Fencepost = func.Fencepost.ToString(),
                    InterfaceID = iface.InterfaceID.ToString(),
                    SerializedArgs = func.Args,
                    SerializedReturns = func.Returns,
                    CannotCallInCrossProcess = func.BannedInCrossProc ? "1" : "0"
                };
                
                jsonIface.Functions.Add(jsonFunc);
            }
            
            File.WriteAllText(Path.Combine(basePath, $"{iface.InterfaceName}Map.json"), JsonSerializer.Serialize(jsonIface, SourceGenerationContext.Default.ClientInterface));
        }
        
        Console.WriteLine("Done");
    }
}