using System.Text.Json.Serialization;

namespace SteamworksDumper.Standalone.OldJSONFormat;

public class ClientInterface
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("functions")]
    public required List<ClientFunction> Functions { get; set; }
}