using Banco.API.Domain.Contas;
using Banco.API.Domain.Contas.Dto;
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

        public IHttpActionResult Put(ContasDto conta, decimal valor, int tipo)
        {
            _ContasRepository.Put(conta, valor, tipo);
            return Ok();
        }

        [HttpGet, Route(template: "api/contas/PutTransferencia")]
        public IHttpActionResult Put(ContasDto conta1, ContasDto conta2, decimal valor)
        {
            _ContasRepository.PutTransferencia(conta1, conta2, valor);
            return Ok();
        }

        public IHttpActionResult Delete(decimal conta)
        {
            _ContasRepository.Delete(conta);
            return Ok();
        }
    }
}
