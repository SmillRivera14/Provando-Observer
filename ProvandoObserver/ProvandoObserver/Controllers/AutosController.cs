using Microsoft.AspNetCore.Mvc;
using ProvandoObserver.Manipulación;

namespace ProvandoObserver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutosController : Controller
    {
        #region obtener autos
        [HttpGet]
        [Route("Get-Autos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetListaAutos()
        {
            string path = ObtenerRuta.ObtenerPath("JAutos.json");

            var clientes = Manipulaciones.GetAutos(path);

            return Ok(clientes);
        }
        #endregion

        #region obtener autos
        [HttpGet]
        [Route("Get-Renta-card")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRentaCard()
        {
            string path = ObtenerRuta.ObtenerPath("JRentaCard.json");
            var clientes = Manipulaciones.GetRencard(path);

            return Ok(clientes);
        }
        #endregion

        #region suscribirAutos
        [HttpGet]
        [Route("GetAutosSuscritos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAutosSuscritos()
        {
            var clientes = Manipulaciones.SuscribirAutos();

            return Ok(clientes);
        }
        #endregion
    }
}
