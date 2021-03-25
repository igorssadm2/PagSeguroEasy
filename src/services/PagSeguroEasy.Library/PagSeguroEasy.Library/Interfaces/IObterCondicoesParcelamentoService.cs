using PagSeguroEasy.Library.ViewModels;

namespace PagSeguroEasy.Library.Services
{
    public interface IObterCondicoesParcelamentoService
    {
        PagCondicoesParcelamentoViewModel ObterCondicoesParcelamento(decimal valor, string IdSessao, string cardBrand);
    }
}