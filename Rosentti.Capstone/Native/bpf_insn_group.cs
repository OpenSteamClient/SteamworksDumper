namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum bpf_insn_group : uint
{
    BPF_GRP_INVALID = 0,
    BPF_GRP_LOAD,
    BPF_GRP_STORE,
    BPF_GRP_ALU,
    BPF_GRP_JUMP,
    BPF_GRP_CALL,
    BPF_GRP_RETURN,
    BPF_GRP_MISC,
    BPF_GRP_ENDING,
}
