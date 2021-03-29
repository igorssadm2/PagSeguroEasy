

using PagSeguroEasy.Library.DTOS;
using PagSeguroEasy.Library.Utils;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PagSeguroEasy.Library.Services
{
    public class PostWebApiService : IPostWebApiService
    {
        public RetornoPagamentoDTO ExecutePOSTWebAPI(string resourceName, object classObj)
        {
            using (var client = new HttpClient())
            {
                //Bypass SSL Certificate if you want, otherwise remove this line of code
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;
                RetornoPagamentoDTO returnPagamentoDTO = new RetornoPagamentoDTO();

                var retornoserealizer = Serialize.SerializeData(classObj);
                var httpContent = new StringContent(retornoserealizer, Encoding.UTF8, "application/xml");
                var response = client.PostAsync(resourceName, httpContent).Result;
                var jsonString = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    returnPagamentoDTO.transaction = Deserialize.DeserializeData<RetornoPagamentoDTO.Transaction>(jsonString);

                    return returnPagamentoDTO;
                }
                else
                {
                    var retornoErro = Deserialize.DeserializeData<DTOS.Errors>(jsonString);
                    returnPagamentoDTO.Errors = retornoErro;
                }

                return returnPagamentoDTO;
                //}
                //catch (Exception exp)
                //{
                //    return new ReturnPagamentoDTO();
                //}
            }
        }
    }
}
