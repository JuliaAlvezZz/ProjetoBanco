using Banco.API.Domain.Contas.Dto;
using Banco.API.Domain.Operações.Dto;
using System.Collections.Generic;

namespace Banco.API.Domain.Contas
{
    public interface IContasRepository
    {
        IEnumerable<ContasDto> Get();
        ContasDto GetPorValor(decimal valor, int tipo);
        void Post(ContasDto conta);
        void Put(SaqDepDto op);
        void PutTransferencia(TransDto op);
        void Delete(decimal conta);
    }
}
