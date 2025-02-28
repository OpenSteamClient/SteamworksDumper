namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum bpf_reg : uint
{
    BPF_REG_INVALID = 0,
    BPF_REG_A,
    BPF_REG_X,
    BPF_REG_R0,
    BPF_REG_R1,
    BPF_REG_R2,
    BPF_REG_R3,
    BPF_REG_R4,
    BPF_REG_R5,
    BPF_REG_R6,
    BPF_REG_R7,
    BPF_REG_R8,
    BPF_REG_R9,
    BPF_REG_R10,
    BPF_REG_ENDING,
}
