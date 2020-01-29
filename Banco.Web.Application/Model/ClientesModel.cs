using System;

namespace Banco.Web.Application.Model
{
    class ClientesModel
    {
        public ClientesModel()
        {

        }

        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Tel { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
    }
}
