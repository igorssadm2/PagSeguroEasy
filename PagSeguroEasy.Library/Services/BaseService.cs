using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace PagSeguroEasy.Library.Services
{
   public class BaseService
    {
        protected readonly IConfiguration _configuration;

        public BaseService(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        protected T Deserializer<T>(string xml)
        {
            T instance;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var stringreader = new StringReader(xml))
                {
                    instance = (T)xmlSerializer.Deserialize(stringreader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return instance;
        }

        public string ConverteObjectParaJSon<T>(T obj)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream();
                ser.WriteObject(ms, obj);
                string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return jsonString;
            }
            catch
            {
                throw;
            }
        }
    }
}
