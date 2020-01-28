using System;
using System.Data;
using System.Data.SqlClient;

namespace Banco.API.Repository.Infra
{
    public class ConexaoRepository : IConexaoRepository
    {
        private string _connectionString = "data source = ESTAGIO06; Integrated Security = SSPI; Initial Catalog = banco";

        private readonly SqlConnection _connection;

        private SqlCommand Command { get; set; }

        public ConexaoRepository()
        {
            _connection = Connect();
        }

        public void AddParameter(string nomeParametro, object valor)
        {
            Command.Parameters.Add(new SqlParameter(nomeParametro, valor ?? DBNull.Value));
        }

        public SqlConnection Connect()
        {
            var connection = new SqlConnection(_connectionString);

            if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public void ExecuteProcedure(string nomeProcedure)
        {
            Command = new SqlCommand(nomeProcedure, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public void ExecuteNonQuery()
        {
            Command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader()
        {
            return Command.ExecuteReader();
        }

        public void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType paramterType = DbType.Int16)
        {
            Command.Parameters.Add(new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.ReturnValue,
                DbType = paramterType
            });
        }

        public int ExecuteNoQueryWithReturn()
        {
            try
            {
                AddParameterReturn();
                Connect();
                Command.ExecuteNonQuery();
                return int.Parse(Command.Parameters["@RETURN_VALUE"].Value.ToString());
            }
            catch (SqlException ex)
            {
                return -1;
            }
        }
    }
}