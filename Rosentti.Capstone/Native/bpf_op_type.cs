namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum bpf_op_type : uint
{
    BPF_OP_INVALID = 0,
    BPF_OP_REG,
    BPF_OP_IMM,
    BPF_OP_OFF,
    BPF_OP_MEM,
    BPF_OP_MMEM,
    BPF_OP_MSH,
    BPF_OP_EXT,
}
