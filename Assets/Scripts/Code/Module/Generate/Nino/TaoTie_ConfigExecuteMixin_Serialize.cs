/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigDoActionByExecuteMixin
    {
        public static ConfigDoActionByExecuteMixin.SerializationHelper NinoSerializationHelper = new ConfigDoActionByExecuteMixin.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigDoActionByExecuteMixin>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigDoActionByExecuteMixin value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.Actions);
            }

            public override ConfigDoActionByExecuteMixin Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigDoActionByExecuteMixin value = new ConfigDoActionByExecuteMixin();
                value.Actions = reader.ReadArray<TaoTie.ConfigAbilityAction>();
                return value;
            }
            #endregion
        }
    }
}