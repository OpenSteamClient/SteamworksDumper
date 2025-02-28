namespace Rosentti.Capstone.Native;

public unsafe partial struct cs_opt_skipdata
{
    [NativeTypeName("const char *")]
    public sbyte* mnemonic;

    [NativeTypeName("cs_skipdata_cb_t")]
    public delegate* unmanaged[Cdecl]<byte*, nuint, nuint, void*, nuint> callback;

    public void* user_data;
}
