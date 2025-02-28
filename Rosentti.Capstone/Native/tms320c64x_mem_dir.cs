namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum tms320c64x_mem_dir : uint
{
    TMS320C64X_MEM_DIR_INVALID = 0,
    TMS320C64X_MEM_DIR_FW,
    TMS320C64X_MEM_DIR_BW,
}
