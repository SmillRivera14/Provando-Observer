using EASendMail;
using SmtpClient = EASendMail.SmtpClient;

namespace ProvandoObserver.Manipulación
{
    public class MandarGmail
    {
        public static string EnviarCorreo(string correoDestino, string asunto, string mensajeCorreo)
        {
            string Mensaje = "Error al enviar correo.";

            try
            {
                SmtpMail objetoCorreo = new SmtpMail("TryIt");

                objetoCorreo.From = "pruebascorreo307@gmail.com";
                objetoCorreo.To = correoDestino;
                objetoCorreo.Subject = asunto;
                objetoCorreo.TextBody = mensajeCorreo;

                SmtpServer objetoServidor = new SmtpServer("smtp.gmail.com");

                objetoServidor.User = "pruebascorreo307@gmail.com";
                objetoServidor.Password = "iubzpqtwoyruigru"; // Reemplaza "tu_contraseña" con la contraseña de tu cuenta de Gmail o contraseña de aplicación generada
                objetoServidor.Port = 587;
                objetoServidor.ConnectType = SmtpConnectType.ConnectSSLAuto; // Usa STARTTLS con el puerto 587

                SmtpClient objetoCliente = new SmtpClient();
                objetoCliente.SendMail(objetoServidor, objetoCorreo);
                Mensaje = "Correo Enviado Correctamente.";
            }
            catch (Exception ex)
            {
                Mensaje = "Error al enviar correo. " + ex.Message;
            }
            return Mensaje;
        }
    }
}
