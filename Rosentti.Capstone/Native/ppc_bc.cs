namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum ppc_bc : uint
{
    PPC_BC_INVALID = 0,
    PPC_BC_LT = (0 << 5) | 12,
    PPC_BC_LE = (1 << 5) | 4,
    PPC_BC_EQ = (2 << 5) | 12,
    PPC_BC_GE = (0 << 5) | 4,
    PPC_BC_GT = (1 << 5) | 12,
    PPC_BC_NE = (2 << 5) | 4,
    PPC_BC_UN = (3 << 5) | 12,
    PPC_BC_NU = (3 << 5) | 4,
    PPC_BC_SO = (4 << 5) | 12,
    PPC_BC_NS = (4 << 5) | 4,
}
