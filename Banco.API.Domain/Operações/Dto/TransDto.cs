using Banco.API.Domain.Contas.Dto;

namespace Banco.API.Domain.Operações.Dto
{
    public class TransDto
    {
        public TransDto()
        {

        }

        public ContasDto Conta1 { get; set; }
        public ContasDto Conta2 { get; set; }
        public decimal Valor { get; set; }
    }
}
