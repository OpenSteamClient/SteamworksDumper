namespace SteamworksDumper.Utils;

public static class SigScanner
{
    private static bool PatternCheck(int nOffset, byte[] arrPattern, ReadOnlySpan<byte> memory)
    {
        if (nOffset + arrPattern.Length > memory.Length)
            return false;
            //throw new ArgumentOutOfRangeException(nameof(nOffset));
        
        for (int i = 0; i < arrPattern.Length; i++)
        {
            if (arrPattern[i] == 0x0)
                continue;
 
            if (arrPattern[i] != memory[nOffset + i]) {
                return false;
            }
        }
 
        return true;
    }
    
    private static byte[] ParsePatternString(string pattern, string mask)
    {
        byte[] patternbytes = new byte[pattern.Length];

        for (int i = 0; i < mask.Length; i++)
        {
            if (mask[i] == '?') {
                patternbytes[i] = 0x0;
            } else {
                patternbytes[i] = (byte)pattern[i];
            }
        }

        return patternbytes.ToArray();
    }
    
    /// <summary>
    /// Searches for the specified signature in the given haystack.
    /// </summary>
    /// <param name="haystack"></param>
    /// <param name="sign"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    public static long FindSignature(ReadOnlySpan<byte> haystack, string sign, string mask)
    {
        byte[] arrPattern = ParsePatternString(sign, mask);
        
        for (int nModuleIndex = 0; nModuleIndex < haystack.Length; nModuleIndex++)
        {
            if (PatternCheck(nModuleIndex, arrPattern, haystack))
            {
                return nModuleIndex;
            }
        }

        return 0;
    }
    
    /// <summary>
    /// Searches for the specified signature in the given haystack.
    /// </summary>
    /// <param name="haystack"></param>
    /// <param name="addedOffset">The offset to add if returned value was non-zero</param>
    /// <param name="name">Name of the function being searched for for debugging purposes</param>
    /// <param name="required">If this is true and the return value is non-zero, this method will throw an exception.</param>
    /// <param name="sign"></param>
    /// <param name="mask"></param>
    /// <returns></returns>
    /// <exception cref="MissingMethodException">If required is true and the method was not found</exception>
    public static long FindSignatureHelper(ReadOnlySpan<byte> haystack, long addedOffset, string name, bool required, string sign, string mask)
    {
        var pos = FindSignature(haystack, sign, mask);
        
        if (required && pos == 0)
            throw new MissingMethodException($"Failed to find required method {name} by signature");

        if (pos != 0)
        {
            pos += addedOffset;
            Console.WriteLine($"Found {name} at {GhidraUtil.GetOffsetForGhidra(pos)}");
        }
        else
        {
            Console.WriteLine($"Did not find {name}! (optional)");
        }
        
        return pos;
    }
}