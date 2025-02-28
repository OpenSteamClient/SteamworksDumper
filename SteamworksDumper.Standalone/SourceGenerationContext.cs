using System.Text.Json.Serialization;

namespace SteamworksDumper.Standalone;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(OldJSONFormat.ClientFunction))]
[JsonSerializable(typeof(OldJSONFormat.ClientInterface))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}