using System.Runtime.CompilerServices;

namespace Rosentti.Capstone.Native;

public partial struct cs_tms320c64x
{
    [NativeTypeName("uint8_t")]
    public byte op_count;

    [NativeTypeName("cs_tms320c64x_op[8]")]
    public _operands_e__FixedBuffer operands;

    [NativeTypeName("__AnonymousRecord_tms320c64x_L67_C2")]
    public _condition_e__Struct condition;

    [NativeTypeName("__AnonymousRecord_tms320c64x_L71_C2")]
    public _funit_e__Struct funit;

    [NativeTypeName("unsigned int")]
    public uint parallel;

    public partial struct _condition_e__Struct
    {
        [NativeTypeName("unsigned int")]
        public uint reg;

        [NativeTypeName("unsigned int")]
        public uint zero;
    }

    public partial struct _funit_e__Struct
    {
        [NativeTypeName("unsigned int")]
        public uint unit;

        [NativeTypeName("unsigned int")]
        public uint side;

        [NativeTypeName("unsigned int")]
        public uint crosspath;
    }

    [InlineArray(8)]
    public partial struct _operands_e__FixedBuffer
    {
        public cs_tms320c64x_op e0;
    }
}
