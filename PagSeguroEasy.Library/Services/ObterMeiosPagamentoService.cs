

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagSeguroEasy.Library.Configurations;
using PagSeguroEasy.Library.Entitys;
using System;
using System.Net;
using System.Net.Http;

namespace PagSeguroEasy.Library.Services
{ 
    public class ObterMeiosPagamentoService : BaseService,IObterMeiosPagamentoService
    {
        public ObterMeiosPagamentoService(IConfiguration configuration):base(configuration)
        {

        }
        public PagMeiosPagamentos ObterMeiosdePagamento(decimal valor, string IdSessao)
        {
            PagMeiosPagamentos meiosPgto = new PagMeiosPagamentos();

            var URLBase = _configuration.GetSection("URLBASE").Value + _configuration.GetSection("MEIOSDEPAGAMENTOS").Value.Replace("{{Valor}}",
                Convert.ToString(valor).Replace(",", ".")).Replace("{{IdSessao}}", IdSessao);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.pagseguro.com.br.v1+json;charset=ISO-8859-1");
            HttpResponseMessage response = client.GetAsync(URLBase).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;

                meiosPgto = JsonConvert.DeserializeObject<PagMeiosPagamentos>(jsonString);

            }
            return meiosPgto;
        }

    }
}
