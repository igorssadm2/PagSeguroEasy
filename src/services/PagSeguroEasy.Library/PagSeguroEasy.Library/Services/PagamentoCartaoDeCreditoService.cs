

using PagSeguroEasy.Library.Configurations;
using PagSeguroEasy.Library.DTOS;
using PagSeguroEasy.Library.Entities;
using PagSeguroEasy.Library.Enums;
using PagSeguroEasy.Library.ViewModels;
using System.Collections.Generic;
using static PagSeguroEasy.Library.ViewModels.PagCondicoesParcelamentoViewModel;

namespace PagSeguroEasy.Library.Services
{
    public class PagamentoCartaoDeCreditoService : IPagamentoCartaoDeCreditoService
    {
        public IGerarPayment _GerarPayment { get; set; }
        private readonly IPostWebApiService _postWebApiService;
        public PagamentoCartaoDeCreditoService(IGerarPayment gerarPayment,IPostWebApiService postWebApiService)
        {
            _GerarPayment = gerarPayment;
            _postWebApiService = postWebApiService;
        }
        public RetornoPagamentoDTO PagamentoCartaoCredito(string token, string email, string cardtoken, string IdUser, string emailUser, string ValorFrete, int tipoFrete, CondicoesParcelamento condicoesParcelamento, DadosComprador dadosComprador, CartaoDeCredito cartaoDeCredito, List<ShoppingCarItems> itensCarrinho)
        {

            Payment payment = _GerarPayment.GetPayment(IdUser, emailUser, cardtoken, ValorFrete, tipoFrete, condicoesParcelamento, MeioPagamentoEnum.creditCard, null, dadosComprador, cartaoDeCredito, itensCarrinho);

            var URLBase = GlobalConfiguration.CARTAODECREDITO.Replace("{{email}}", email).Replace("{{token}}", token);

            var retorno = _postWebApiService.ExecutePOSTWebAPI(URLBase, payment);
            return retorno;
        }
    }
}
