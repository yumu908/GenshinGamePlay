/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigDoActionBeforeRemoveMixin
    {
        [LitJson.Extensions.JsonIgnore]
        public static ConfigDoActionBeforeRemoveMixin.SerializationHelper NinoSerializationHelper = new ConfigDoActionBeforeRemoveMixin.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigDoActionBeforeRemoveMixin>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigDoActionBeforeRemoveMixin value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.Actions);
            }

            public override ConfigDoActionBeforeRemoveMixin Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigDoActionBeforeRemoveMixin value = new ConfigDoActionBeforeRemoveMixin();
                value.Actions = reader.ReadArray<TaoTie.ConfigAbilityAction>();
                return value;
            }
            #endregion
        }
    }
}