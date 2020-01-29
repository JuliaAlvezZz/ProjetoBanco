using Banco.Web.Application.Model;
using System.Net.Http;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System;

namespace Banco.Web.Application
{
    class ClientesController
    {
        static HttpClient user = new HttpClient();

        public HttpResponseMessage Post(ClientesModel cliente)
        {
            string URL = "https://localhost:50970/api/clientes/Post";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.PostAsync(URL, cliente, new JsonMediaTypeFormatter
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
            string URL = "https://localhost:50970/api/clientes/Get";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.GetAsync(URL).Result;

            return response;
        }

        public HttpResponseMessage GetPorCpf(decimal cpf)
        {
            string URL = "https://localhost:50970/api/clientes/GetPorCpf" + "?cpf=" + cpf.ToString();
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.GetAsync(URL).Result;

            return response;
        }

        public HttpResponseMessage Put(ClientesModel cliente)
        {
            string URL = "https://localhost:50970/api/clientes/Put";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.PutAsync(URL, cliente, new JsonMediaTypeFormatter
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

        public HttpResponseMessage Delete(ClientesModel cliente)
        {
            string URL = "https://localhost:50970/api/clientes/Delete";
            user.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = user.PostAsync(URL, cliente, new JsonMediaTypeFormatter
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
