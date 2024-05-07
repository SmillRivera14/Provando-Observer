using ProvandoObserver.Interface;
using ProvandoObserver.Modelos;

namespace ProvandoObserver
{
    public class CHoteles
    {
        private List<IObservador> Lista = new List<IObservador>();

        public void Suscribir(IObservador observador)
        {
            Lista.Add(observador);
        }

        public void Desuscribir(IObservador observador)
        {
            Lista.Remove(observador);
        }

        private void NotificarObservadores()
        {
            foreach (var observador in Lista)
            {
                observador.Actualizar();
            }
        }

        public void Enviar(string email)
        {
            foreach (var observador in Lista)
            {
                if (observador is CClientes cliente)
                {
                    cliente.Email = email;
                }
            }

            NotificarObservadores();
        }
    }
}
