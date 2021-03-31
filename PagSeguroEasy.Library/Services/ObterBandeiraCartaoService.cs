using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagSeguroEasy.Library.Configurations;
using PagSeguroEasy.Library.ViewModels;
using System.Net;
using System.Net.Http;

namespace PagSeguroEasy.Library.Services
{
    public class ObterBandeiraCartaoService :BaseService, IObterBandeiraCartaoService
    {
        public ObterBandeiraCartaoService(IConfiguration configuration):base(configuration)
        {
            
        }
        public PagBandeiraCartaoViewModel ObterBandeiraCartao(string IdSessao, string BinCartao)
        {
            PagBandeiraCartaoViewModel bandeira = new PagBandeiraCartaoViewModel();

            var URLBase = _configuration.GetSection("BANDEIRACARTAO").Value.Replace("{{BinCartao}}", 
                BinCartao).Replace("{{IdSessao}}", IdSessao);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.pagseguro.com.br.v1+json;charset=ISO-8859-1");
            HttpResponseMessage response = client.GetAsync(URLBase).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                bandeira = JsonConvert.DeserializeObject<PagBandeiraCartaoViewModel>(jsonString);
            }
            return bandeira;
        }
    }
}
