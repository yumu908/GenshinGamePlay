/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigDoActionByTickMixin
    {
        public static ConfigDoActionByTickMixin.SerializationHelper NinoSerializationHelper = new ConfigDoActionByTickMixin.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigDoActionByTickMixin>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigDoActionByTickMixin value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.CompressAndWrite(ref value.Interval);
                writer.Write(value.TickFirstOnAdd);
                writer.Write(value.Actions);
            }

            public override ConfigDoActionByTickMixin Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigDoActionByTickMixin value = new ConfigDoActionByTickMixin();
                reader.DecompressAndReadNumber<System.UInt32>(ref value.Interval);
                reader.Read<System.Boolean>(ref value.TickFirstOnAdd, 1);
                value.Actions = reader.ReadArray<TaoTie.ConfigAbilityAction>();
                return value;
            }
            #endregion
        }
    }
}