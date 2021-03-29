using PagSeguroEasy.Library.Entitys;

namespace PagSeguroEasy.Library.Services
{
    public interface IObterMeiosPagamentoService
    {
        PagMeiosPagamentos ObterMeiosdePagamento(decimal valor, string IdSessao);
    }
}