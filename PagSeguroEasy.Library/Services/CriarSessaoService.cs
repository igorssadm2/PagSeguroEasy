using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using static PagSeguroEasy.Library.Models.PagSeguroSessao;

namespace PagSeguroEasy.Library.Services
{
    public class CriarSessaoService : BaseService, ICriarSessaoService
    {
       
        public CriarSessaoService(IConfiguration configuration):base(configuration)
        {

        }
  
        public session CriarSessao(string email, string token)
        {
            try
            {
                session Sessao = new session();
                var teste = _configuration.GetSection("URLBASE");
                var URLBase = _configuration.GetSection("URLBASE").Value + _configuration.GetSection("CRIARSESSAO").Value.Replace("{{email}}", email).Replace("{{token}}", token);
                var client = new HttpClient();
                
                HttpResponseMessage response = client.PostAsync(URLBase, null).Result;
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Sessao = this.Deserializer<session>(result);
                }

                return Sessao;
            }
            catch (System.Exception ex)
            {
               throw new System.Exception(ex.Message,ex);
            }
        }
    }
}
