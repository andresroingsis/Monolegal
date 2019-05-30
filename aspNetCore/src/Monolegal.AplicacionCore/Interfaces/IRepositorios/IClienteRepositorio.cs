using Monolegal.AplicacionCore.Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal.AplicacionCore.Interfaces.IRepositorios
{
    public interface IClienteRepositorio
    {
        Task<IReadOnlyList<Cliente>> ObtenerClientesAsync();

        Task AgregarClienteAsync(Cliente cliente);

        Task<Cliente> ObtenerClientePorCedulaAsync(string numeroDeCedula);

        Task ActualizarClienteAsync(Cliente cliente);
    }
}
