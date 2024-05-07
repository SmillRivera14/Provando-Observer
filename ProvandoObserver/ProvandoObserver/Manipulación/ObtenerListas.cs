using Newtonsoft.Json;
using ProvandoObserver.Interface;
namespace ProvandoObserver.Manipulación
{
    public class ObtenerListas : IObtenerListas 
    {

        private string path;

        public ObtenerListas(string path)
        {
            this.path = path;
        }
        
        public List<T> GetLista<T>()
        {
            string PathCompleto = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            string Leer = File.ReadAllText(PathCompleto);

            List<T> listaDeserializada  = JsonConvert.DeserializeObject<List<T>>(Leer) ?? throw new Exception("Error en la deserialización del JSON o la lista es nula.");
            return listaDeserializada;
        }
    }
}
