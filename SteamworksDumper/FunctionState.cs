namespace SteamworksDumper;

public enum FunctionState
{
    /// <summary>
    /// No data yet.
    /// </summary>
    NoData,
    
    /// <summary>
    /// A CUtlBuffer was initialized. This may be an IPC method
    /// </summary>
    UtlBufferInitialized,
        
    /// <summary>
    /// We got the IPC command code (1 = Interface call)
    /// </summary>
    GotIPCCommandCode,
        
    /// <summary>
    /// Got the command code
    /// </summary>
    GotIPCInterfaceCode,
        
    /// <summary>
    /// Got the function ID, we are in argument serialization
    /// </summary>
    GotFunctionID,
        
    /// <summary>
    /// Got the fencepost, all args got
    /// </summary>
    GotFencepost,
        
    /// <summary>
    /// Send function has been called, we're in IPC result code deserialization
    /// </summary>
    GotIPCSend,
        
    /// <summary>
    /// IPC result code has been retrieved, need to find deserialization
    /// </summary>
    GotIPCResultCode,
        
    /// <summary>
    /// deserialize returns
    /// </summary>
    InReturnDeserialization,
        
    /// <summary>
    /// The function has been processed
    /// </summary>
    EndDumping
}