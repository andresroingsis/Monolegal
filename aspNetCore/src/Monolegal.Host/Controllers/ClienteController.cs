using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monolegal.AplicacionCore.Entidades.Negocio;
using Monolegal.AplicacionCore.Interfaces.IServicios;
using Monolegal.Host.Models.Clientes;

namespace Monolegal.Host.Controllers
{
    /// <summary>
    /// Controlador de Clientes
    /// </summary>
    public class ClienteController : MonolegalController
    {
        private readonly IMapper _Mapper;

        private readonly IClienteServicio _ClienteServicio;

        /// <summary>
        /// Inicializa el controlador
        /// </summary>
        /// <param name="mapper">Gestor de mapeo de entidades</param>
        /// <param name="clienteServicio">Servicio de clientes</param>
        public ClienteController(IMapper mapper, IClienteServicio clienteServicio)
        {
            _Mapper = mapper;
            _ClienteServicio = clienteServicio;
        }

        /// <summary>
        /// Obtiene un listado de clientes registrados
        /// </summary>
        /// <returns>Clientes consultados</returns>
        [HttpGet("ObtenerClientes")]
        public async Task<IReadOnlyList<ClienteDto>> ObtenerClientesAsync()
        {
            return await _ClienteServicio.ObtenerClientesAsync();
        }

        /// <summary>
        /// Registra un cliente en el sistema
        /// </summary>
        /// <param name="clienteARegistrar">Datos del cliente a registrar</param>
        /// <returns></returns>
        [HttpPost("RegistrarCliente")]
        public async Task RegistrarClienteAsync([FromBody] RegistrarCliente clienteARegistrar)
        {
            await _ClienteServicio.AgregarClienteAsync(_Mapper.Map<ClienteDto>(clienteARegistrar));
        }
    }
}