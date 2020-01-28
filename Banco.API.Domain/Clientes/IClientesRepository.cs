using System.Collections.Generic;

namespace Banco.API.Domain.Clientes
{
    public interface IClientesRepository
    {
        IEnumerable<ClientesDto> Get();
        ClientesDto Get(decimal cpf);
        void Post(ClientesDto cliente);
        void Put(ClientesDto cliente);
        void Delete(decimal cpf);
    }
}
