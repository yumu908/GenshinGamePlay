/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigVariableCondition
    {
        [LitJson.Extensions.JsonIgnore]
        public static ConfigVariableCondition.SerializationHelper NinoSerializationHelper = new ConfigVariableCondition.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigVariableCondition>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigVariableCondition value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.WriteCommonVal<TaoTie.BaseGearValue>(value.leftValue==null?TypeInfo<TaoTie.BaseGearValue>.Type:value.leftValue.GetType(),value.leftValue);
                writer.CompressAndWriteEnum<TaoTie.CompareMode>(value.mode);
                writer.Write(value.rightValue);
            }

            public override ConfigVariableCondition Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigVariableCondition value = new ConfigVariableCondition();
                value.leftValue = reader.ReadCommonVal<TaoTie.BaseGearValue>();
                reader.DecompressAndReadEnum<TaoTie.CompareMode>(ref value.mode);
                reader.Read<System.Single>(ref value.rightValue, Nino.Shared.Mgr.ConstMgr.SizeOfUInt);
                return value;
            }
            #endregion
        }
    }
}