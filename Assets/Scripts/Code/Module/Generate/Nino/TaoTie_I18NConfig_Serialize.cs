/* this is generated by nino */
namespace TaoTie
{
    public partial class I18NConfig
    {
        [LitJson.Extensions.JsonIgnore]
        public static I18NConfig.SerializationHelper NinoSerializationHelper = new I18NConfig.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<I18NConfig>
        {
            #region NINO_CODEGEN
            public override void Serialize(I18NConfig value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.CompressAndWrite(value.Id);
                writer.Write(value.Key);
                writer.Write(value.Chinese);
                writer.Write(value.English);
            }

            public override I18NConfig Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                I18NConfig value = new I18NConfig();
                value.Id = reader.DecompressAndReadNumber<System.Int32>();
                value.Key = reader.ReadString();
                value.Chinese = reader.ReadString();
                value.English = reader.ReadString();
                return value;
            }
            #endregion
        }
    }
}