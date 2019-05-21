using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Monolegal.AplicacionCore.Entidades.Persistencia;
using Monolegal.AplicacionCore.Utilidades.Configuraciones;

namespace Monolegal.Infraestructura.Datos
{
    public class ContextoDeDatos
    {
        private Mongo _Opciones;

        private readonly IMongoDatabase _BaseDeDatos;

        public IMongoCollection<Cliente> Clientes
        {
            get
            {
                return _BaseDeDatos.GetCollection<Cliente>("Clientes");
            }
        }

        public IMongoCollection<Factura> Facturas
        {
            get
            {
                return _BaseDeDatos.GetCollection<Factura>("Facturas");
            }
        }

        public ContextoDeDatos(IOptions<Mongo> opciones)
        {
            _Opciones = opciones.Value;
            var mongoCliente = new MongoClient(_Opciones.Conexion);

            if (mongoCliente != null)
            {
                _BaseDeDatos = mongoCliente.GetDatabase(_Opciones.NombreBaseDeDatos);
            }
        }
    }
}
