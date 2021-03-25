using PagSeguroEasy.Library.Configurations;
using PagSeguroEasy.Library.InputModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using static PagSeguroEasy.Library.Models.PagSeguroSessao;

namespace PagSeguroEasy.Library.Services
{
    public class ObterTokenCartaoService : BaseService, IObterTokenCartaoService
    {
        public card ObterTokenCartao(ObterTokenCartaoInputModel obterTokenCartaoInput)
        {
            try
            {
                card card = new card();
                var URLBase = GlobalConfiguration.OBTERTOKENCARTAO;
                var client = new HttpClient();


                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("sessionId", obterTokenCartaoInput.sessionId),
                    new KeyValuePair<string, string>("amount", Convert.ToString(obterTokenCartaoInput.amount).Replace(",", ".")),
                    new KeyValuePair<string, string>("cardNumber", obterTokenCartaoInput.cardNumber),
                    new KeyValuePair<string, string>("cardBrand", obterTokenCartaoInput.cardBrand),
                    new KeyValuePair<string, string>("cardCvv", obterTokenCartaoInput.cardCvv),
                    new KeyValuePair<string, string>("cardExpirationMonth", obterTokenCartaoInput.cardExpirationMonth.ToString()),
                    new KeyValuePair<string, string>("cardExpirationYear", obterTokenCartaoInput.cardExpirationYear.ToString())
                });

                HttpResponseMessage response = client.PostAsync(URLBase, content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    card = this.Deserializer<card>(result);
                }
                return card;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
