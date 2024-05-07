using ProvandoObserver.Interface;
using ProvandoObserver.Modelos;
using System.IO;
using System.Text.Json;
using static ProvandoObserver.Modelos.CRentaCar;

namespace ProvandoObserver.Manipulación
{
    public class Manipulaciones
    {

        public Manipulaciones() { }

        #region ObtenerDatosCLientes
        public static dynamic GetClientes(string path)
        {
            try
            {
                ObtenerListas datosClientes = new ObtenerListas(path);

                List<CClientes> _Clientes = datosClientes.GetLista<CClientes>();

                return _Clientes;
            }
            catch (Exception ex)
            {
                return $"\nERROR AL LEER EL ARCHIVO CLIENTES\nRUTA: {path}\n\n EXCEPCIÓN:{ex}";
            }

        }
        #endregion

        #region datosAutos
        public static dynamic GetAutos(string path)
        {
            try
            {
                ObtenerListas datosAutos = new ObtenerListas(path);

                List<CAutos> _Autos = datosAutos.GetLista<CAutos>();

                return _Autos;
            }
            catch (Exception ex)
            {
                return $"\nERROR AL LEER EL ARCHIVO CLIENTES\nRUTA: {path}\n\n EXCEPCIÓN:{ex}";
            }
        }
        #endregion

        #region datosRencard
        public static dynamic GetRencard(string path)
        {
            try
            {
                ObtenerListas datosRentacard = new ObtenerListas(path);

                List<CRentaCard> _Rentacard = datosRentacard.GetLista<CRentaCard>();

                return _Rentacard;
            }
            catch (Exception ex)
            {
                return $"\nERROR AL LEER EL ARCHIVO CLIENTES\nRUTA: {path}\n\n EXCEPCIÓN:{ex}";
            }
        }
        #endregion

        #region poner autos en rencard
        public static string SuscribirAutos()
        {
            try
            {
               string pahtAutos= ObtenerRuta.ObtenerPath("JAutos.json");
               string pathRentaCard = ObtenerRuta.ObtenerPath("JRentaCard.json");

                ObtenerListas datosAutos = new(pahtAutos);
                ObtenerListas datosRentcard = new(pathRentaCard);

                List<CAutos> _Autos = datosAutos.GetLista<CAutos>();
                List<CRentaCard> _RentaCard = datosRentcard.GetLista<CRentaCard>();

                CRentaCard cRentaCard = _RentaCard[0];
                cRentaCard.Renta_carro.Autos.AddRange(_Autos);
                cRentaCard.Renta_carro.AutosDisponibles = cRentaCard.Renta_carro.Autos.Count;

                var opcionesSerializacion = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string Reserializar = JsonSerializer.Serialize(cRentaCard, opcionesSerializacion);

                return Reserializar;
            }
            catch (Exception ex)
            {
                return $"\nERROR AL SERIALIZAR JSON DE HOTELES\n EXCEPCIÓN:{ex}";
            }
        }
        #endregion

        #region Buscar Por email
        public static dynamic BuscarClientePorEmail(string email)
        {
            try
            {
                string path= ObtenerRuta.ObtenerPath("JCliente.json");

                ObtenerListas datosClientes = new ObtenerListas(path);

                List<CClientes> _Clientes = datosClientes.GetLista<CClientes>();

                return _Clientes.FirstOrDefault(a => a.Email == email)!;
            }
            catch (Exception ex)
            {
                return $"\nERROR AL BUSCAR EMAIL\n EXEPCIÓN:\n {ex}\n";

            }
        }
        #endregion

        #region ObtenerDatosHotel
        public static dynamic GetHotel(string path)
        {
            try
            {
                ObtenerListas datosHotel = new ObtenerListas(path);

                List<CHotel> hotel = datosHotel.GetLista<CHotel>();

                return hotel;

            }
            catch (Exception ex)
            {
                return $"\nERROR AL LEER EL JSON HOTEL\nRUTA: {path}\n\n EXCEPCIÓN:{ex}";

            }
        }
        #endregion

        #region Obtener datos objeto Hotel

        public static dynamic GetObjeto(string path, string tipoHabitacion)
        {

            try
            {
                ObtenerListas datosHotel = new ObtenerListas(path);

                List<CHotel> _hotel = datosHotel.GetLista<CHotel>();

                var primerHotel = _hotel.FirstOrDefault();

                if (primerHotel != null)
                {
                    var habitacion = primerHotel.Habitaciones.FirstOrDefault(h => h.Tipo == tipoHabitacion);

                    return $"Tipo: {habitacion.Tipo}\n Precio por noche: {habitacion.PrecioPorNoche}\n Disponibilidad: {habitacion.Disponibilidad}";
                }
                else if (tipoHabitacion == null)
                {
                    throw new Exception($"No se encontró la habitación '{tipoHabitacion}' en el hotel.");
                }

                return null;

            }
            catch (FileNotFoundException ex)
            {
                return $"El archivo no se encontró. Verifica la ruta o el nombre del archivo.\n{ex}";
            }
            catch (JsonException ex)
            {
                return $"Hubo un error al deserializar el archivo JSON./n{ex}";
            }
            catch (Exception ex)
            {
                return $"HUBO UN FALLO\n{ex.Message}";
            }
        }
        #endregion

        #region enviarGamil

        public static dynamic EnviarEmail(string _Path, string Email)
        {
            try
            {
                ObtenerListas datosCliente = new ObtenerListas(_Path);

                List<CClientes> listaClientes = datosCliente.GetLista<CClientes>();

                var clienteCoincidente = listaClientes.FirstOrDefault(c => c.Email == Email);

                if (clienteCoincidente != null)
                {
                    CHoteles cHoteles = new();

                    // Suscribir el cliente como observador antes de llamar a Prueba
                    cHoteles.Suscribir(clienteCoincidente);

                    // Actualizar el email en el cliente antes de llamar a Prueba
                    cHoteles.Enviar(Email);
                }
                else
                {
                    return "No se encontró ningún cliente con el correo electrónico proporcionado.";
                }

                return "Se envió el correo exitosamente.";
            }
            catch (Exception e)
            {
                return $"ERROR EN EL ENVÍO\n{e}";
            }
        }
        #endregion

        #region Desuscribir cliente
        public static dynamic Descliente(string _Path, string Email)
        {
            try
            {
                ObtenerListas datosclientes = new (_Path);

                List<CClientes> listaClientes = datosclientes.GetLista<CClientes>();

                var clienteCoincidente = listaClientes.FirstOrDefault(c => c.Email == Email);

                CHoteles cHoteles = new();

                if (clienteCoincidente != null)
                {
                    // Suscribir el cliente como observador antes de llamar a Prueba
                    cHoteles.Desuscribir(clienteCoincidente);
                }
                else
                {
                    return "No se encontró ningún cliente con el correo electrónico proporcionado.";
                }

                return "SE ELIMINO CORRECTAMENTE";

            }
            catch (JsonException ex)
            {
                return $"ERROR AL DESUSCRIBIR CLIENTE\n{ex}";
            }
        }

        #endregion
    }
}
