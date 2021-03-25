using PagSeguroEasy.Library.Entities;
using PagSeguroEasy.Library.Enums;
using PagSeguroEasy.Library.ViewModels;
using System.Collections.Generic;

namespace PagSeguroEasy.Library.Services
{
    public interface IGerarPayment
    {
        Payment GetPayment(string IdUser, string emailUser, string cardToken, string ValorFrete, int tipoFrete, PagCondicoesParcelamentoViewModel.CondicoesParcelamento condicoesParcelamento, MeioPagamentoEnum meioPagamento, Bank bank, DadosComprador dadosComprador, CartaoDeCredito cartaoDeCredito, List<ShoppingCarItems> itensCarrinho);
    }
}