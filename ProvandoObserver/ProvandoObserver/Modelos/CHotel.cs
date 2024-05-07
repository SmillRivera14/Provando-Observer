using ProvandoObserver.Interface;

namespace ProvandoObserver.Modelos
{
    public class CHotel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Estrellas { get; set; }
        public List<string> Servicios { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public class Habitacion
        {
            public string Tipo { get; set; }
            public int PrecioPorNoche { get; set; }
            public int Disponibilidad { get; set; }
        }
    }
}