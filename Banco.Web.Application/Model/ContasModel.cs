using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Web.Application.Model
{
    public class ContasModel
    {
        public ContasModel()
        {

        }

        public decimal Conta { get; set; }
        public decimal Saldo { get; set; }
        public decimal Cpf { get; set; }
    }
}
