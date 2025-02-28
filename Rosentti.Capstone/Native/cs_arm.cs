using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_arm
{
    [NativeTypeName("bool")]
    public byte usermode;

    public int vector_size;

    public arm_vectordata_type vector_data;

    public arm_cpsmode_type cps_mode;

    public arm_cpsflag_type cps_flag;

    public arm_cc cc;

    [NativeTypeName("bool")]
    public byte update_flags;

    [NativeTypeName("bool")]
    public byte writeback;

    [NativeTypeName("bool")]
    public byte post_index;

    public arm_mem_barrier mem_barrier;

    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_arm_op[36]")]
    public _operands_e__FixedBuffer operands;

    [InlineArray(36)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_arm_op e0;
    }
}
