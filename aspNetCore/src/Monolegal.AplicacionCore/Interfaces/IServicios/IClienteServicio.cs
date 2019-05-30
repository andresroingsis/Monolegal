using Monolegal.AplicacionCore.Entidades.Negocio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monolegal.AplicacionCore.Interfaces.IServicios
{
    public interface IClienteServicio
    {
        Task<IReadOnlyList<ClienteDto>> ObtenerClientesAsync();

        Task AgregarClienteAsync(ClienteDto cliente);

        Task GestionarNotificacionesPorClienteAsync(string numeroDeCedula);
    }
}
