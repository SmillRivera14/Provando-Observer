using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvandoObserver.Interface;
using ProvandoObserver.Manipulación;

namespace ProvandoObserver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private string path = ObtenerRuta.ObtenerPath("JCliente.json");

        #region getLista
        // GET: PrimerController
        [HttpGet]
        [Route("Get-CLientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetListaClientes()
        {
            var clientes = Manipulaciones.GetClientes(path);

            return Ok(clientes);
        }
        #endregion

        #region Cliente hotel por email
        // GET: PrimerController
        [HttpGet]
        [Route("Obtener-Por-Email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BuscarCliente(string email)
        {
            var variable = Manipulaciones.BuscarClientePorEmail(email);

            if (variable == null)
            {
                return NotFound();
            }
            return Ok(variable);
        }
        #endregion

        #region Suscribir

        [HttpGet]
        [Route("Suscribir-cliente")]
        public IActionResult Suscribir (string email)
        {
            var susi = Manipulaciones.EnviarEmail(path, email);
            if (susi == null)
            {
                return NotFound();
            }
            return Ok(susi);
        }

        #endregion

        #region Desuscribir cliente
        [HttpGet]
        [Route("Desuscribir-cliente")]
        public IActionResult Desuscribir(string email)
        {
            var susi = Manipulaciones.Descliente(path, email);
            if (susi == null)
            {
                return NotFound();
            }
            return Ok(susi);
        }
        #endregion


    }
}
