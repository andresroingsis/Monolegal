using System.Threading.Tasks;

namespace Monolegal.AplicacionCore.Interfaces.IServicios
{
    public interface INotificacionServicio
    {
        Task EnviarNotificacion(string correoDestino, string tituloDeCorreob, string mensajeDeCorreo);
    }
}
