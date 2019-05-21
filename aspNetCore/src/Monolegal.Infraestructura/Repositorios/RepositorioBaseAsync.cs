using Microsoft.Extensions.Options;
using Monolegal.Infraestructura.Datos;
using Monolegal.AplicacionCore.Interfaces.IRepositorios;
using Monolegal.AplicacionCore.Utilidades.Configuraciones;

namespace Monolegal.Infraestructura.Repositorios
{
    /// <summary>
    /// Repositorio padre, gestiona el DbContext
    /// </summary>
    public class RepositorioBaseAsync : IRepositorioBaseAsync
    {
        protected readonly ContextoDeDatos _Contexto;

        public RepositorioBaseAsync(IOptions<Mongo> options)
        {
            _Contexto = new ContextoDeDatos(options);
        }
    }
}
