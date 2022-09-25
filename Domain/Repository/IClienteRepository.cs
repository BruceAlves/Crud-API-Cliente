using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> BuscarCliente();

        Cliente CadastrarCliente(Cliente cliente);

        Cliente EditarCliente(Cliente cliente);

        void DeletarCliente(int id);

    }
}
