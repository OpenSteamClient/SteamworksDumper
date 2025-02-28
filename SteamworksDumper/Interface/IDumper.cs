namespace SteamworksDumper.Interface;

public interface IDumper : IDisposable
{
    public long FindSignature(string name, bool required, string sign, string mask);
    
    /// <summary>
    /// Tries to get a read-write reference to the section by the given name.
    /// </summary>
    /// <param name="sectionName"></param>
    /// <param name="section"></param>
    /// <returns>True if the section exists and was retrieved, false if the section does not exist.</returns>
    public bool TryGetSection(string sectionName, out Span<byte> section);
    public bool TryGetSectionInfo(string sectionName, out int endAddr, out int startAddr);
    
    /// <summary>
    /// Does the given offset land in any data section (.rodata, .data, etc)
    /// </summary>
    /// <param name="offset"></param>
    /// <returns></returns>
    public bool IsOffsetInData(int offset);

    public IEnumerable<long> GetRefsToSymbol(long value);
    public long GetImportRelocByName(string name);

    public IEnumerable<ClientInterface> DumpAll();
}