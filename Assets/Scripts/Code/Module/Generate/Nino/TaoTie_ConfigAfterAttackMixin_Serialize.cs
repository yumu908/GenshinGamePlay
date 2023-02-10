/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigAfterAttackMixin
    {
        public static ConfigAfterAttackMixin.SerializationHelper NinoSerializationHelper = new ConfigAfterAttackMixin.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigAfterAttackMixin>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigAfterAttackMixin value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.Actions);
            }

            public override ConfigAfterAttackMixin Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigAfterAttackMixin value = new ConfigAfterAttackMixin();
                value.Actions = reader.ReadArray<TaoTie.ConfigAbilityAction>();
                return value;
            }
            #endregion
        }
    }
}