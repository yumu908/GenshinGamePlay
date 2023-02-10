/* this is generated by nino */
namespace TaoTie
{
    public partial class AttributeConfig
    {
        public static AttributeConfig.SerializationHelper NinoSerializationHelper = new AttributeConfig.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<AttributeConfig>
        {
            #region NINO_CODEGEN
            public override void Serialize(AttributeConfig value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.CompressAndWrite(value.Id);
                writer.Write(value.Key);
                writer.Write(value.Name);
                writer.CompressAndWrite(value.Type);
                writer.CompressAndWrite(value.Show);
                writer.CompressAndWrite(value.Affected);
                writer.Write(value.MaxAttr);
                writer.Write(value.Desc);
            }

            public override AttributeConfig Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                AttributeConfig value = new AttributeConfig();
                value.Id = reader.DecompressAndReadNumber<System.Int32>();
                value.Key = reader.ReadString();
                value.Name = reader.ReadString();
                value.Type = reader.DecompressAndReadNumber<System.Int32>();
                value.Show = reader.DecompressAndReadNumber<System.Int32>();
                value.Affected = reader.DecompressAndReadNumber<System.Int32>();
                value.MaxAttr = reader.ReadString();
                value.Desc = reader.ReadString();
                return value;
            }
            #endregion
        }
    }
}