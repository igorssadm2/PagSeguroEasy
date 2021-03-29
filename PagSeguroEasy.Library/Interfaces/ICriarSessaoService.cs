using PagSeguroEasy.Library.Models;

namespace PagSeguroEasy.Library.Services
{
    public interface ICriarSessaoService
    {
        PagSeguroSessao.session CriarSessao(string email, string token);
    }
}