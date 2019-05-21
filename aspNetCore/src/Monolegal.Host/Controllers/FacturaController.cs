using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Monolegal.AplicacionCore.Interfaces.IServicios;
using Monolegal.Host.Models.Facturas;
using Monolegal.AplicacionCore.Entidades.Negocio;

namespace Monolegal.Host.Controllers
{
    /// <summary>
    /// Controlador de facturas
    /// </summary>
    public class FacturaController : MonolegalController
    {
        private readonly IMapper _Mapper;

        private readonly IFacturaServicio _FacturaServicio;

        /// <summary>
        /// Inicializa el controlador
        /// </summary>
        /// <param name="mapper">Gestor de mapeo de entidades</param>
        /// <param name="facturaServicio">Servicio de facturas</param>
        public FacturaController(IMapper mapper, IFacturaServicio facturaServicio)
        {
            _Mapper = mapper;
            _FacturaServicio = facturaServicio;
        }

        /// <summary>
        /// Obtiene lista de string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpPost("AgregarFactura")]
        public async Task<RegistrarFactura> AgregarFacturaAsync([FromBody] RegistrarFactura facturaARegistrar)
        {
            var facturaRegistrada = await _FacturaServicio.AgregarFacturaAsync(_Mapper.Map<FacturaDto>(facturaARegistrar));
            return _Mapper.Map<RegistrarFactura>(facturaRegistrada);
        }
    }
}