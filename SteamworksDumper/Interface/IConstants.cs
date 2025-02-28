namespace SteamworksDumper.Interface;

/// <summary>
/// Provides constants used in the decompilation process.
/// </summary>
public interface IConstants
{
    // Misc.
    
    /// <summary>
    /// Function used to initialize a CUtlBuffer at the start of IPC (and other) functions
    /// </summary>
    public long CUtlBufferCtorOffset { get; }
    
    /// <summary>
    /// Function called to send and receive results via IPC
    /// </summary>
    public long SendSerializedFnOffset { get; }
    
    /// <summary>
    /// Freeing function called at the end of result deserialization
    /// </summary>
    public long IPCClientFreeFuncCallReturnBuffer { get; }
    
    // Putters
    public long PutBytesFnOffset { get; }
    public long PutSingleByteFnOffset { get; }
    public long PutUInt64Offset { get; }
    public long PutSNIdentityFnOffset { get; }
    public long PutProtobufFnOffset { get; }
    public long PutParamStringArrayFnOffset { get; }
    
    // Getters
    public long GetBytesFnOffset { get; }
    public long GetBytesFn2Offset { get; }
    public long GetUInt64FnOffset { get; }
    public long GetSingleByteFnOffset { get; }
}