using System.Data;
using System.Data.SqlClient;

namespace Banco.API.Repository.Infra
{
    public interface IConexaoRepository
    {
        SqlConnection Connect();
        void ExecuteProcedure(string procedure);
        SqlDataReader ExecuteReader();
        void AddParameter(string nomeParametro, object valor);
        void ExecuteNonQuery();
    }
}
