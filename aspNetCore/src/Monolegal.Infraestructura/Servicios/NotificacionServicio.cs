using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Monolegal.AplicacionCore.Interfaces.IServicios;

namespace Monolegal.Infraestructura.Servicios
{
    public class NotificacionServicio : INotificacionServicio
    {
        public async Task EnviarNotificacion(string correoDestino, string tituloDeCorreo, string mensajeDeCorreo)
        {
            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential("andresroingsis@gmail.com", "")
            };

            using (var message = new MailMessage("andresroingsis@gmail.com", correoDestino)
            {
                Subject = tituloDeCorreo,
                Body = mensajeDeCorreo
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
