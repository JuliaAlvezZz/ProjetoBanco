using Banco.API.Domain.Clientes;
using System.Web.Http;

namespace Banco.API.API.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClientesRepository _ClientesRepository;

        public ClientesController(IClientesRepository ClientesRepository)
        {
            _ClientesRepository = ClientesRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_ClientesRepository.Get());
        }

        [HttpGet, Route(template: "api/clientes/GetPorCpf")]
        public IHttpActionResult Get(decimal cpf)
        {
            return Ok(_ClientesRepository.Get(cpf));
        }

        public IHttpActionResult Post(ClientesDto cliente)
        {
            _ClientesRepository.Post(cliente);
            return Ok();
        }

        public IHttpActionResult Put(ClientesDto cliente)
        {
            _ClientesRepository.Put(cliente);
            return Ok();
        }

        public IHttpActionResult Delete(decimal cpf)
        {
            _ClientesRepository.Delete(cpf);
            return Ok();
        }
    }
}
