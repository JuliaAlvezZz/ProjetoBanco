using Banco.API.Domain.Contas.Dto;
using System.Collections.Generic;

namespace Banco.API.Domain.Contas
{
    public interface IContasRepository
    {
        IEnumerable<ContasDto> Get();
        ContasDto GetPorValor(decimal valor, int tipo);
        void Post(ContasDto conta);
        void Put(ContasDto conta, decimal valor, int tipo);
        void PutTransferencia(ContasDto conta1, ContasDto conta2, decimal valor);
        void Delete(decimal conta);
    }
}
