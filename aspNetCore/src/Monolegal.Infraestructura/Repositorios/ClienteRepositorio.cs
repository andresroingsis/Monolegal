using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Monolegal.AplicacionCore.Entidades.Persistencia;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;
using Monolegal.AplicacionCore.Utilidades.Configuraciones;
using MongoDB.Driver;

namespace Monolegal.Infraestructura.Repositorios
{
    /// <summary>
    /// Repositorio de los clientes
    /// </summary>
    public class ClienteRepositorio : RepositorioBaseAsync, IClienteRepositorio
    {
        /// <summary>
        /// Inicializa el repositorio
        /// </summary>
        /// <param name="options">Opciones de configuracion</param>
        public ClienteRepositorio(IOptions<Mongo> options) : base(options)
        {

        }

        public async Task AgregarClienteAsync(Cliente cliente)
        {
            try
            {
                await _Contexto.Clientes.InsertOneAsync(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task ActualizarClienteAsync(Cliente cliente)
        {
            try
            {
                await _Contexto.Clientes.ReplaceOneAsync(cli => cli.Id == cliente.Id, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> ObtenerClientePorCedulaAsync(string numeroDeCedula)
        {
            try
            {
                var consulta = await _Contexto.Clientes.FindAsync(c => c.NumeroDeCedula.ToString() == numeroDeCedula);
                return await consulta.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IReadOnlyList<Cliente>> ObtenerClientesAsync()
        {
            try
            {
                return await _Contexto.Clientes.AsQueryable().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
