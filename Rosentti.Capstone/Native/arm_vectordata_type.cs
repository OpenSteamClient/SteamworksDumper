namespace Rosentti.Capstone.Native;

[NativeTypeName("unsigned int")]
public enum arm_vectordata_type : uint
{
    ARM_VECTORDATA_INVALID = 0,
    ARM_VECTORDATA_I8,
    ARM_VECTORDATA_I16,
    ARM_VECTORDATA_I32,
    ARM_VECTORDATA_I64,
    ARM_VECTORDATA_S8,
    ARM_VECTORDATA_S16,
    ARM_VECTORDATA_S32,
    ARM_VECTORDATA_S64,
    ARM_VECTORDATA_U8,
    ARM_VECTORDATA_U16,
    ARM_VECTORDATA_U32,
    ARM_VECTORDATA_U64,
    ARM_VECTORDATA_P8,
    ARM_VECTORDATA_F16,
    ARM_VECTORDATA_F32,
    ARM_VECTORDATA_F64,
    ARM_VECTORDATA_F16F64,
    ARM_VECTORDATA_F64F16,
    ARM_VECTORDATA_F32F16,
    ARM_VECTORDATA_F16F32,
    ARM_VECTORDATA_F64F32,
    ARM_VECTORDATA_F32F64,
    ARM_VECTORDATA_S32F32,
    ARM_VECTORDATA_U32F32,
    ARM_VECTORDATA_F32S32,
    ARM_VECTORDATA_F32U32,
    ARM_VECTORDATA_F64S16,
    ARM_VECTORDATA_F32S16,
    ARM_VECTORDATA_F64S32,
    ARM_VECTORDATA_S16F64,
    ARM_VECTORDATA_S16F32,
    ARM_VECTORDATA_S32F64,
    ARM_VECTORDATA_U16F64,
    ARM_VECTORDATA_U16F32,
    ARM_VECTORDATA_U32F64,
    ARM_VECTORDATA_F64U16,
    ARM_VECTORDATA_F32U16,
    ARM_VECTORDATA_F64U32,
    ARM_VECTORDATA_F16U16,
    ARM_VECTORDATA_U16F16,
    ARM_VECTORDATA_F16U32,
    ARM_VECTORDATA_U32F16,
}
