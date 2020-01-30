using Banco.API.Domain.Contas;
using Banco.API.Domain.Contas.Dto;
using Banco.API.Domain.Operações.Dto;
using Banco.API.Repository.Infra;
using System;
using System.Collections.Generic;

namespace Banco.API.Repository
{
    public class ContasRepository : ConexaoRepository, IContasRepository
    {
        public ContasRepository(IConexaoRepository connection)
        {

        }

        public IEnumerable<ContasDto> Get()
        {
            ExecuteProcedure("ListConta");

            var contas = new List<ContasDto>();

            using (var reader = ExecuteReader())
                while (reader.Read())
                    contas.Add(new ContasDto
                    {
                        Conta = Convert.ToDecimal(reader["Num_Conta"].ToString()),
                        Saldo = Convert.ToDecimal(reader["Num_Saldo"].ToString()),
                        Cpf = Convert.ToDecimal(reader["Num_Cpf"].ToString())
                    });

            return contas;
        }

        public ContasDto GetPorValor(decimal valor, int tipo)
        {
            if (tipo == 0)
            {
                ExecuteProcedure("SelContaCliente");
                AddParameter("@Num_Cpf", valor);
            }else if(tipo == 1)
            {
                ExecuteProcedure("ExtConta");
                AddParameter("@Num_Conta", valor);
            }

            using (var reader = ExecuteReader())
                if (reader.Read())
                    return new ContasDto
                    {
                        Conta = Convert.ToDecimal(reader["Num_Conta"].ToString()),
                        Saldo = Convert.ToDecimal(reader["Num_Saldo"].ToString()),
                        Cpf = Convert.ToDecimal(reader["Num_Cpf"].ToString())
                    };

            return null;
        }

        public void Post(ContasDto conta)
        {
            ExecuteProcedure("InsConta");
            AddParameter("@Num_Conta", conta.Conta);
            AddParameter("@Num_Cpf", conta.Cpf);
            ExecuteNonQuery();
        }

        public void Put(SaqDepDto op)
        {
            if (op.Tipo == 0)
            {
                ExecuteProcedure("DepConta");
                AddParameter("@Num_Conta", op.Conta.Conta);
                AddParameter("@Num_Deposito", op.Valor);
            }else if (op.Tipo == 1)
            {
                ExecuteProcedure("SaqConta");
                AddParameter("@Num_Conta", op.Conta.Conta);
                AddParameter("@Num_Saque", op.Valor);
            }
            
            ExecuteNonQuery();
        }

        public void PutTransferencia(TransDto op)
        {
            ExecuteProcedure("TraConta");
            AddParameter("@Num_ContaOri", op.Conta1.Conta);
            AddParameter("@Num_ContaDes", op.Conta2.Conta);
            AddParameter("@Num_Valor", op.Valor);
            ExecuteNonQuery();
        }

        public void Delete(decimal conta)
        {
            ExecuteProcedure("DelConta");
            AddParameter("@Num_Conta", conta);
            ExecuteNonQuery();
        }
    }
}
