using System.Threading.Tasks;
using Monolegal.AplicacionCore.Entidades.Persistencia;

namespace Monolegal.AplicacionCore.Interfaces.IRepositorios
{
    public interface IFacturaRepositorio
    {
        Task<Factura> AgregarFacturaAsync(Factura factura);
    }
}
