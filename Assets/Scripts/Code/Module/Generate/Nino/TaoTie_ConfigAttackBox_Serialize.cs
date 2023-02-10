/* this is generated by nino */
namespace TaoTie
{
    public partial class ConfigAttackBox
    {
        public static ConfigAttackBox.SerializationHelper NinoSerializationHelper = new ConfigAttackBox.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ConfigAttackBox>
        {
            #region NINO_CODEGEN
            public override void Serialize(ConfigAttackBox value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.CompressAndWriteEnum<TaoTie.CheckHitLayerType>(value.CheckHitLayerType);
                TaoTie.ConfigHitScene.NinoSerializationHelper.Serialize(value.HitScene, writer);
                writer.WriteCommonVal<TaoTie.ConfigBornType>(value.Born);
                TaoTie.DynamicVector3.NinoSerializationHelper.Serialize(value.Size, writer);
            }

            public override ConfigAttackBox Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ConfigAttackBox value = new ConfigAttackBox();
                reader.DecompressAndReadEnum<TaoTie.CheckHitLayerType>(ref value.CheckHitLayerType);
                value.HitScene = TaoTie.ConfigHitScene.NinoSerializationHelper.Deserialize(reader);
                value.Born = reader.ReadCommonVal<TaoTie.ConfigBornType>();
                value.Size = TaoTie.DynamicVector3.NinoSerializationHelper.Deserialize(reader);
                return value;
            }
            #endregion
        }
    }
}