using System;
using System.IO;
namespace ProvandoObserver.Manipulación
{

    public class ObtenerRuta
    {
        public static string ObtenerPath(string nombreArchivo)
        {
            // Obteniendo la ruta del directorio del proyecto
            string rutaProyecto = Directory.GetCurrentDirectory();

            // Agregando manualmente el resto de la ruta hasta el archivo
            string rutaArchivo = Path.Combine(rutaProyecto, "Datos", nombreArchivo);

            return rutaArchivo;
        }
    }
}
