/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigAbilityModifier
    {
        public static ConfigAbilityModifier.SerializationHelper NinoSerializationHelper = new ConfigAbilityModifier.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigAbilityModifier>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigAbilityModifier value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.ModifierName);
                writer.CompressAndWrite(ref value.Duration);
                writer.CompressAndWriteEnum<TaoTie.StackingType>(value.StackingType);
                writer.CompressAndWrite(ref value.StackLimitCount);
                writer.Write(value.Mixins);
            }

            public override ConfigAbilityModifier Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigAbilityModifier value = new ConfigAbilityModifier();
                value.ModifierName = reader.ReadString();
                reader.DecompressAndReadNumber<System.Int32>(ref value.Duration);
                reader.DecompressAndReadEnum<TaoTie.StackingType>(ref value.StackingType);
                reader.DecompressAndReadNumber<System.Int32>(ref value.StackLimitCount);
                value.Mixins = reader.ReadArray<TaoTie.ConfigAbilityMixin>();
                return value;
            }
            #endregion
        }
    }
}