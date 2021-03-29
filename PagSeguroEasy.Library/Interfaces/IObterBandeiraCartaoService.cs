using PagSeguroEasy.Library.ViewModels;

namespace PagSeguroEasy.Library.Services
{
    public interface IObterBandeiraCartaoService
    {
        PagBandeiraCartaoViewModel ObterBandeiraCartao(string IdSessao, string BinCartao);
    }
}