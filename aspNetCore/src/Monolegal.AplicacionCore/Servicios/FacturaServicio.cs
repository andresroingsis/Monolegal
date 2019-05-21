using AutoMapper;
using System.Threading.Tasks;
using Monolegal.AplicacionCore.Entidades.Negocio;
using Monolegal.AplicacionCore.Interfaces.IServicios;
using Monolegal.AplicacionCore.Entidades.Persistencia;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;

namespace Monolegal.AplicacionCore.Servicios
{
    /// <summary>
    /// Servicio de facturas
    /// </summary>
    public class FacturaServicio : IFacturaServicio
    {
        private readonly IMapper _Mapper;

        private readonly IFacturaRepositorio _FacturaRepositorio;

        public FacturaServicio(IMapper mapper, IFacturaRepositorio facturaRepositorio)
        {
            _Mapper = mapper;
            _FacturaRepositorio = facturaRepositorio;
        }

        public async Task<FacturaDto> AgregarFacturaAsync(FacturaDto factura)
        {
            await _FacturaRepositorio.AgregarFacturaAsync(_Mapper.Map<Factura>(factura));
            return factura;
        }
    }
}
