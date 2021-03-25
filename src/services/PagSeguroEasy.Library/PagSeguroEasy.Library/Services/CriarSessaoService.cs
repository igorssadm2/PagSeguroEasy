using PagSeguroEasy.Library.Configurations;
using System.Net;
using System.Net.Http;
using static PagSeguroEasy.Library.Models.PagSeguroSessao;

namespace PagSeguroEasy.Library.Services
{
    public class CriarSessaoService : BaseService, ICriarSessaoService
    {
        public session CriarSessao(string email, string token)
        {
            try
            {
                session Sessao = new session();
                var URLBase = GlobalConfiguration.URLBASE + GlobalConfiguration.CRIARSESSAO.Replace("{{email}}", email).Replace("{{token}}", token);
                var client = new HttpClient();

                HttpResponseMessage response = client.PostAsync(URLBase, null).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Sessao = this.Deserializer<session>(result);
                }

                return Sessao;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
