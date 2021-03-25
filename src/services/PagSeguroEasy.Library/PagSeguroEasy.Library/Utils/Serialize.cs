

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PagSeguroEasy.Library.Utils
{
   public static class Serialize
    {
        public static string SerializeData(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (StringWriter stringwriter = new StringWriter())
            {
                // removes namespace

                var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(dataToSerialize.GetType(), "");

                var xw = XmlWriter.Create(stringwriter, settings);

                serializer.Serialize(xw, dataToSerialize, emptyNs);
                return stringwriter.ToString();
            }
        }
    }
}
