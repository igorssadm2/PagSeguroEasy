using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PagSeguroEasy.Library.Configurations;
using PagSeguroEasy.Library.ViewModels;
using System;
using System.Net;
using System.Net.Http;

namespace PagSeguroEasy.Library.Services
{
    public class ObterCondicoesParcelamentoService : BaseService,IObterCondicoesParcelamentoService
    {
        public ObterCondicoesParcelamentoService(IConfiguration configuration):base(configuration)
        {

        }
        public PagCondicoesParcelamentoViewModel ObterCondicoesParcelamento(decimal valor, string IdSessao, string cardBrand)
        {
            PagCondicoesParcelamentoViewModel meiosPgto = new PagCondicoesParcelamentoViewModel();

            var URLBase = _configuration.GetSection("CONDICOESDEPARCELAMENTO").Value.Replace("{{IdSessao}}", IdSessao).Replace("{{Valor}}", 
                Convert.ToString(valor).Replace(",", ".")).Replace("{{cardBrand}}", cardBrand);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.pagseguro.com.br.v1+json;charset=ISO-8859-1");
            HttpResponseMessage response = client.GetAsync(URLBase).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                meiosPgto.root = JsonConvert.DeserializeObject<PagCondicoesParcelamentoViewModel.Root>(jsonString);
            }
            return meiosPgto;
        }
    }
}
