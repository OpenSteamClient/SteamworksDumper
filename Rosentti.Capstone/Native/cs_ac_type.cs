namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum cs_ac_type : uint
{
    CS_AC_INVALID = 0,
    CS_AC_READ = 1 << 0,
    CS_AC_WRITE = 1 << 1,
}
