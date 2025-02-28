using System.Runtime.InteropServices;

namespace Rosentti.Capstone.Native;

public static unsafe partial class Methods
{
    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint cs_version(int* major, int* minor);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte cs_support(int query);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern cs_err cs_open(cs_arch arch, cs_mode mode, [NativeTypeName("csh *")] nuint* handle);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern cs_err cs_close([NativeTypeName("csh *")] nuint* handle);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern cs_err cs_option([NativeTypeName("csh")] nuint handle, cs_opt_type type, [NativeTypeName("size_t")] nuint value);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern cs_err cs_errno([NativeTypeName("csh")] nuint handle);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* cs_strerror(cs_err code);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint cs_disasm([NativeTypeName("csh")] nuint handle, [NativeTypeName("const uint8_t *")] byte* code, [NativeTypeName("size_t")] nuint code_size, [NativeTypeName("uint64_t")] nuint address, [NativeTypeName("size_t")] nuint count, cs_insn** insn);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void cs_free(cs_insn* insn, [NativeTypeName("size_t")] nuint count);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern cs_insn* cs_malloc([NativeTypeName("csh")] nuint handle);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte cs_disasm_iter([NativeTypeName("csh")] nuint handle, [NativeTypeName("const uint8_t **")] byte** code, [NativeTypeName("size_t *")] nuint* size, [NativeTypeName("uint64_t *")] nuint* address, cs_insn* insn);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* cs_reg_name([NativeTypeName("csh")] nuint handle, [NativeTypeName("unsigned int")] uint reg_id);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* cs_insn_name([NativeTypeName("csh")] nuint handle, [NativeTypeName("unsigned int")] uint insn_id);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* cs_group_name([NativeTypeName("csh")] nuint handle, [NativeTypeName("unsigned int")] uint group_id);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte cs_insn_group([NativeTypeName("csh")] nuint handle, [NativeTypeName("const cs_insn *")] cs_insn* insn, [NativeTypeName("unsigned int")] uint group_id);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte cs_reg_read([NativeTypeName("csh")] nuint handle, [NativeTypeName("const cs_insn *")] cs_insn* insn, [NativeTypeName("unsigned int")] uint reg_id);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte cs_reg_write([NativeTypeName("csh")] nuint handle, [NativeTypeName("const cs_insn *")] cs_insn* insn, [NativeTypeName("unsigned int")] uint reg_id);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int cs_op_count([NativeTypeName("csh")] nuint handle, [NativeTypeName("const cs_insn *")] cs_insn* insn, [NativeTypeName("unsigned int")] uint op_type);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int cs_op_index([NativeTypeName("csh")] nuint handle, [NativeTypeName("const cs_insn *")] cs_insn* insn, [NativeTypeName("unsigned int")] uint op_type, [NativeTypeName("unsigned int")] uint position);

    [DllImport("capstone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern cs_err cs_regs_access([NativeTypeName("csh")] nuint handle, [NativeTypeName("const cs_insn *")] cs_insn* insn, [NativeTypeName("cs_regs")] ushort* regs_read, [NativeTypeName("uint8_t *")] byte* regs_read_count, [NativeTypeName("cs_regs")] ushort* regs_write, [NativeTypeName("uint8_t *")] byte* regs_write_count);
}
