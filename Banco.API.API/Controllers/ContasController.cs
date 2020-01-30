using Banco.API.Domain.Contas;
using Banco.API.Domain.Contas.Dto;
using Banco.API.Domain.Operações.Dto;
using System.Web.Http;

namespace Banco.API.API.Controllers
{
    public class ContasController : ApiController
    {
        private readonly IContasRepository _ContasRepository;

        public ContasController(IContasRepository ContasRepository)
        {
            _ContasRepository = ContasRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(_ContasRepository.Get());
        }

        [HttpGet, Route(template: "api/contas/GetPorValor")]
        public IHttpActionResult Get(decimal valor, int tipo)
        {
            return Ok(_ContasRepository.GetPorValor(valor, tipo));
        }

        public IHttpActionResult Post(ContasDto conta)
        {
            _ContasRepository.Post(conta);
            return Ok();
        }

        public IHttpActionResult Put(SaqDepDto op)
        {
            _ContasRepository.Put(op);
            return Ok();
        }

        [HttpGet, Route(template: "api/contas/PutTransferencia")]
        public IHttpActionResult Put(TransDto op)
        {
            _ContasRepository.PutTransferencia(op);
            return Ok();
        }

        public IHttpActionResult Delete(decimal conta)
        {
            _ContasRepository.Delete(conta);
            return Ok();
        }
    }
}
