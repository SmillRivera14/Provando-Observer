using ProvandoObserver.Modelos;

namespace ProvandoObserver.Modelos
{
    public class CRentaCar
    {
        public List<CAutos> Autos { get; set; }
        public class CRentaCard
        {
            public CRentaCar Renta_carro { get; set; }
        }
        public int AutosDisponibles { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public string Direccion { get; set; }
        public string NombreEmpresa { get; set; }
        public string Telefono { get; set; }

        public CRentaCar()
        {
            Autos = new List<CAutos>(); // Mueve la inicialización aquí
        }
    }
}
