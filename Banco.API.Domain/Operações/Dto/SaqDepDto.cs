using Banco.API.Domain.Contas.Dto;

namespace Banco.API.Domain.Operações.Dto
{
    public class SaqDepDto
    {
        public SaqDepDto()
        {

        }

        public ContasDto Conta { get; set; }
        public int Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
