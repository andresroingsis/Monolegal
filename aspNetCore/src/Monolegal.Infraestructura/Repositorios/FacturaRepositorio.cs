using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Monolegal.AplicacionCore.Entidades.Persistencia;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;
using Monolegal.AplicacionCore.Utilidades.Configuraciones;

namespace Monolegal.Infraestructura.Repositorios
{
    /// <summary>
    /// Repositorio de facturas
    /// </summary>
    public class FacturaRepositorio : RepositorioBaseAsync, IFacturaRepositorio
    {
        /// <summary>
        /// Inicializa el repositorio
        /// </summary>
        /// <param name="options">Opciones de configuracion</param>
        public FacturaRepositorio(IOptions<Mongo> options) : base(options)
        {

        }

        public async Task<Factura> AgregarFacturaAsync(Factura factura)
        {
            try
            {
                await _Contexto.Facturas.InsertOneAsync(factura);
                return factura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
