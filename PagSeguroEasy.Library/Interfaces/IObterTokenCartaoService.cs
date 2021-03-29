using PagSeguroEasy.Library.InputModels;
using PagSeguroEasy.Library.Models;

namespace PagSeguroEasy.Library.Services
{
    public interface IObterTokenCartaoService
    {
        PagSeguroSessao.card ObterTokenCartao(ObterTokenCartaoInputModel obterTokenCartaoInput);
    }
}