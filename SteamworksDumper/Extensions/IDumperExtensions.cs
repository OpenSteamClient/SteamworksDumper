using SteamworksDumper.Interface;

namespace SteamworksDumper.Extensions;

public static class DumperExtensions
{
    /// <summary>
    /// Get a section by name. Throws if section does not exist.
    /// </summary>
    /// <param name="dumper"></param>
    /// <param name="sectionName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static Span<byte> GetSection(this IDumper dumper, string sectionName)
    {
        if (!dumper.TryGetSection(sectionName, out var ret))
            throw new Exception("Section " + sectionName + " does not exist");

        return ret;
    }
    
    public static void GetSectionInfo(this IDumper dumper, string sectionName, out int endAddr, out int offset)
    {
        if (!dumper.TryGetSectionInfo(sectionName, out endAddr, out offset))
            throw new Exception("Section " + sectionName + " does not exist");
    }
}