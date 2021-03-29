using PagSeguroEasy.Library.DTOS;

namespace PagSeguroEasy.Library.Services
{
    public interface IPostWebApiService
    {
        RetornoPagamentoDTO ExecutePOSTWebAPI(string resourceName, object classObj);
    }
}