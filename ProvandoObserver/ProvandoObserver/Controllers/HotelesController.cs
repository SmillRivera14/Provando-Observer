using Microsoft.AspNetCore.Mvc;
using ProvandoObserver.Manipulación;

namespace ProvandoObserver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private string path = ObtenerRuta.ObtenerPath("JHotel.json");

        #region lista de hoteles

        [HttpGet]
        [Route("Get-Hotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetListaClientes()
        {
            var clientes = Manipulaciones.GetHotel(path);

            return Ok(clientes);

        }

        #endregion

        #region Seleleccionar el tipo de habitación

        [HttpGet]
        [Route("Tipo-de-Habitacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult TipoHabitacion(string tipoHabitacion)
        {
            var susi = Manipulaciones.GetObjeto(path, tipoHabitacion);
            if (susi == null)
            {
                return NotFound();
            }
            return Ok(susi);
        }

        #endregion
    }
}
