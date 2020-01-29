using Banco.Web.Application.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Banco.Web.Application
{
    class ContasController
    {
        static HttpClient user = new HttpClient();

        public HttpResponseMessage Post(ContasModel conta)
        {
            string URL = "https://localhost:50970/api/contas/Post";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.PostAsync(URL, conta, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return response;
        }

        public HttpResponseMessage Get()
        {
            string URL = "https://localhost:50970/api/contas/Get";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.GetAsync(URL).Result;

            return response;
        }

        public HttpResponseMessage GetPorValor(decimal valor, int tipo)
        {
            string URL = "https://localhost:50970/api/contas/GetPorValor" + "?valor=" + valor.ToString() + "&tipo=" + tipo.ToString();
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.GetAsync(URL).Result;

            return response;
        }

        public HttpResponseMessage Delete(ContasModel conta)
        {
            string URL = "https://localhost:50970/api/contas/Delete";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.PostAsync(URL, conta, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver
                    {
                        IgnoreSerializableAttribute = true
                    }
                }
            }).Result;

            return response;
        }
    }
}
