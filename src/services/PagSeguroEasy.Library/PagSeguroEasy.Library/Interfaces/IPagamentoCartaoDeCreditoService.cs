using PagSeguroEasy.Library.DTOS;
using PagSeguroEasy.Library.Entities;
using PagSeguroEasy.Library.ViewModels;
using System.Collections.Generic;
using static PagSeguroEasy.Library.ViewModels.PagCondicoesParcelamentoViewModel;

namespace PagSeguroEasy.Library.Services
{
    public interface IPagamentoCartaoDeCreditoService
    {
        IGerarPayment _GerarPayment { get; set; }

        RetornoPagamentoDTO PagamentoCartaoCredito(string token, string email, string cardtoken, string IdUser, string emailUser, string ValorFrete, int tipoFrete, CondicoesParcelamento condicoesParcelamento, DadosComprador dadosComprador, CartaoDeCredito cartaoDeCredito, List<ShoppingCarItems> itensCarrinho);
    }
}