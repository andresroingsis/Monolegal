using System.Threading.Tasks;
using Monolegal.AplicacionCore.Entidades.Negocio;

namespace Monolegal.AplicacionCore.Interfaces.IServicios
{
    public interface IFacturaServicio
    {
        Task<FacturaDto> AgregarFacturaAsync(FacturaDto factura);
    }
}
