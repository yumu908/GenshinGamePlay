/* this is generated by nino */
namespace TaoTie
{
    public partial class ServerConfigCategory
    {
        public static ServerConfigCategory.SerializationHelper NinoSerializationHelper = new ServerConfigCategory.SerializationHelper();
        public class SerializationHelper: Nino.Serialization.NinoWrapperBase<ServerConfigCategory>
        {
            #region NINO_CODEGEN
            public override void Serialize(ServerConfigCategory value, Nino.Serialization.Writer writer)
            {
                if(value == null)
                {
                    writer.Write(false);
                    return;
                }
                writer.Write(true);
                writer.Write(value.list);
            }

            public override ServerConfigCategory Deserialize(Nino.Serialization.Reader reader)
            {
                if(!reader.ReadBool())
                    return null;
                ServerConfigCategory value = new ServerConfigCategory();
                value.list = reader.ReadList<TaoTie.ServerConfig>();
                return value;
            }
            #endregion
        }
    }
}