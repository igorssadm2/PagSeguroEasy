using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using msShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace msShop.Funcoes
{
    public class FuncoesBase
    {
        protected readonly IConfiguration _configuration;
        protected readonly AppDbContext bancodeDados;



        public FuncoesBase(AppDbContext contextoBancodeDados)
        {
            this.bancodeDados = contextoBancodeDados;
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
