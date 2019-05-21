using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Monolegal.AplicacionCore.Entidades.Negocio;
using Monolegal.AplicacionCore.Interfaces.IServicios;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;
using Monolegal.AplicacionCore.Entidades.Persistencia;

namespace Monolegal.AplicacionCore.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IMapper _Mapper;

        private readonly IClienteRepositorio _ClienteRepositorio;

        public ClienteServicio(IMapper mapper, IClienteRepositorio clienteRepositorio)
        {
            _Mapper = mapper;
            _ClienteRepositorio = clienteRepositorio;
        }

        public async Task AgregarClienteAsync(ClienteDto cliente)
        {
            //cliente.Id = Guid.NewGuid().ToString();
            await _ClienteRepositorio.AgregarClienteAsync(_Mapper.Map<Cliente>(cliente));
        }

        public async Task<IReadOnlyList<ClienteDto>> ObtenerClientesAsync()
        {
            return _Mapper.Map<IReadOnlyList<ClienteDto>>(await _ClienteRepositorio.ObtenerClientesAsync());
        }
    }
}
