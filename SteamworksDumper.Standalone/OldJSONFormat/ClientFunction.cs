using System.Text.Json.Serialization;

namespace SteamworksDumper.Standalone.OldJSONFormat;

public class ClientFunction
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("argc")] //TODO: Dump argc?
    public string Argc { get; set; } = "-1";
    [JsonPropertyName("interfaceid")]
    public required string InterfaceID { get; set; }
    [JsonPropertyName("functionid")]
    public required string FunctionID { get; set; }
    [JsonPropertyName("fencepost")]
    public required string Fencepost { get; set; }

    [JsonPropertyName("cannotcallincrossprocess")]
    public required string CannotCallInCrossProcess { get; set; }
    
    [JsonPropertyName("serializedargs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required List<string> SerializedArgs { get; set; } = new();
    [JsonPropertyName("serializedreturns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public required List<string> SerializedReturns { get; set; } = new();
}