using System.IO;
using System.Xml.Serialization;

namespace PagSeguroEasy.Library.Utils
{
  public static class Deserialize
    {
        public static T DeserializeData<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
