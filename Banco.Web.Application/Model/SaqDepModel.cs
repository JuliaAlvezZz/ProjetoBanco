namespace Banco.Web.Application.Model
{
    public class SaqDepModel
    {
        public SaqDepModel()
        {

        }

        public ContasModel Conta { get; set; }
        public int Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}
