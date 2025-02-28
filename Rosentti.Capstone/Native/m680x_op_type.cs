namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum m680x_op_type : uint
{
    M680X_OP_INVALID = 0,
    M680X_OP_REGISTER,
    M680X_OP_IMMEDIATE,
    M680X_OP_INDEXED,
    M680X_OP_EXTENDED,
    M680X_OP_DIRECT,
    M680X_OP_RELATIVE,
    M680X_OP_CONSTANT,
}
