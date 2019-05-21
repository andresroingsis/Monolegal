using AutoMapper;
using Monolegal.Host.Models.Clientes;
using Monolegal.Host.Models.Facturas;
using Monolegal.AplicacionCore.Entidades.Negocio;
using Monolegal.AplicacionCore.Entidades.Persistencia;

namespace Monolegal.Host.Auxiliares
{
    /// <summary>
    /// Configura el mapeo de las entidades a utilizar
    /// </summary>
    public class MapeoProfile : Profile
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MapeoProfile()
        {
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<RegistrarCliente, ClienteDto>().ReverseMap();
            CreateMap<FacturaDto, Factura>().ReverseMap();
            CreateMap<RegistrarFactura, FacturaDto>().ReverseMap();
        }
    }
}
