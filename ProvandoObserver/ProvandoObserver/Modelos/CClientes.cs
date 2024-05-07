using ProvandoObserver.Interface;
using ProvandoObserver.Manipulación;

namespace ProvandoObserver.Modelos
{
    public class CClientes : IObservador
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public long Telefono { get; set; }

        public void Actualizar()
        {
            string destinatario = Email;
            string asunto = "Se ha registrado en el Hotel";
            string mensaje = $"El cliente: {Nombre} se ha registrado correctamente";

            MandarGmail.EnviarCorreo(destinatario, asunto, mensaje);
        }
    }
}
