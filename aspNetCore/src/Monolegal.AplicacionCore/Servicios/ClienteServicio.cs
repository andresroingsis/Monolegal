using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Monolegal.AplicacionCore.Entidades.Negocio;
using Monolegal.AplicacionCore.Interfaces.IServicios;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;
using Monolegal.AplicacionCore.Entidades.Persistencia;
using System.Linq;
using Monolegal.AplicacionCore.Utilidades;

namespace Monolegal.AplicacionCore.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IMapper _Mapper;

        private readonly IClienteRepositorio _ClienteRepositorio;

        private readonly INotificacionServicio _NotificacionServicio;

        public ClienteServicio(IMapper mapper, IClienteRepositorio clienteRepositorio, INotificacionServicio notificacionServicio)
        {
            _Mapper = mapper;
            _ClienteRepositorio = clienteRepositorio;
            _NotificacionServicio = notificacionServicio;
        }

        public async Task AgregarClienteAsync(ClienteDto cliente)
        {
            await _ClienteRepositorio.AgregarClienteAsync(_Mapper.Map<Cliente>(cliente));
        }

        public async Task<IReadOnlyList<ClienteDto>> ObtenerClientesAsync()
        {
            //await _NotificacionServicio.EnviarNotificacion();
            return _Mapper.Map<IReadOnlyList<ClienteDto>>(await _ClienteRepositorio.ObtenerClientesAsync());
        }

        public async Task GestionarNotificacionesPorClienteAsync(string numeroDeCedula)
        {
            var clienteAGestionar = await _ClienteRepositorio.ObtenerClientePorCedulaAsync(numeroDeCedula);
            var facturasNoPagadasDelCliente = clienteAGestionar.Facturas.Where(factura => !factura.FacturaPagada).ToList();

            if (facturasNoPagadasDelCliente.Count > 0)
            {
                if (facturasNoPagadasDelCliente.Count >= 4 && facturasNoPagadasDelCliente.Any(fact => fact.ValorTotal >= 10000))
                {

                }
                else
                {
                    var listadoDeFacturasANotificarPrimer = facturasNoPagadasDelCliente.Where(fact => fact.Estado == string.Empty);
                    var listadoDeFacturasANotificarSegundo = facturasNoPagadasDelCliente.Where(fact => fact.Estado == Constantes.PRIMER_RECORDATORIO);

                    foreach (var item in listadoDeFacturasANotificarPrimer)
                    {
                        item.Estado = Constantes.PRIMER_RECORDATORIO;
                    }
                    
                    foreach (var item in listadoDeFacturasANotificarSegundo)
                    {
                        item.Estado = Constantes.SEGUNDO_RECORDATORIO;
                    }


                }
            }
        }
    }
}
