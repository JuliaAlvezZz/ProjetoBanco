using System.Collections.Generic;
using System;
using Banco.API.Domain.Clientes;
using Banco.API.Repository.Infra;

namespace Banco.API.Repository
{
    public class ClientesRepository : ConexaoRepository, IClientesRepository
    {
        public ClientesRepository(IConexaoRepository connection) : base()
        {
            
        }

        public IEnumerable<ClientesDto> Get()
        {
            ExecuteProcedure("ListCliente");

            var clientes = new List<ClientesDto>();

            using (var reader = ExecuteReader())
                while (reader.Read())
                    clientes.Add(new ClientesDto
                    {
                        Cpf = Convert.ToDecimal(reader["Num_Cpf"].ToString()),
                        Nome = reader["Nom_Nome"].ToString(),
                        DataNasc = Convert.ToDateTime(reader["Dat_Nasc"].ToString()),
                        Tel = reader["Num_Tel"].ToString(),
                        Endereco = reader["Nom_End"].ToString(),
                        Email = reader["Nom_Email"].ToString(),
                        Status = Convert.ToInt16(reader["Cod_Status"].ToString())
                    });

            return clientes;
        }

        public ClientesDto Get(decimal cpf)
        {
            ExecuteProcedure("SelCliente");
            AddParameter("@Num_Cpf", cpf);

            using (var reader = ExecuteReader())
                if (reader.Read())
                    return new ClientesDto
                    {
                        Cpf = Convert.ToDecimal(reader["Num_Cpf"].ToString()),
                        Nome = reader["Nom_Nome"].ToString(),
                        DataNasc = Convert.ToDateTime(reader["Dat_Nasc"].ToString()),
                        Tel = reader["Num_Tel"].ToString(),
                        Endereco = reader["Nom_End"].ToString(),
                        Email = reader["Nom_Email"].ToString(),
                        Status = Convert.ToInt16(reader["Cod_Status"].ToString())
                    };

            return null;
        }

        public void Post(ClientesDto cliente)
        {
            ExecuteProcedure("InsCliente");
            AddParameter("@Num_Cpf", cliente.Cpf);
            AddParameter("@Nom_Nome", cliente.Nome);
            AddParameter("@Dat_Nasc", cliente.DataNasc);
            AddParameter("@Num_Tel", cliente.Tel);
            AddParameter("@Nom_End", cliente.Endereco);
            AddParameter("@Nom_Email", cliente.Email);
            ExecuteNonQuery();
        }

        public void Put(ClientesDto cliente)
        {
            ExecuteProcedure("UpdCliente");
            AddParameter("@Num_Cpf", cliente.Cpf);
            AddParameter("@Nom_Nome", cliente.Nome);
            AddParameter("@Dat_Nasc", cliente.DataNasc);
            AddParameter("@Num_Tel", cliente.Tel);
            AddParameter("@Nom_End", cliente.Endereco);
            AddParameter("@Nom_Email", cliente.Email);
            AddParameter("@Cod_Status", cliente.Status);
            ExecuteNonQuery();
        }

        public void Delete(decimal cpf)
        {
            ExecuteProcedure("DelCliente");
            AddParameter("@Num_Cpf", cpf);
            ExecuteNonQuery();
        }
    }
}
