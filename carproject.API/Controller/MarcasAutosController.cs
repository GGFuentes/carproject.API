using carproject.Application.Dto;
using carproject.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace carproject.API.Controller
{
    /// <summary>
    /// Controlador REST para consultar marcas de autos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasAutosController
    {
        private readonly IMarcasAutosService _marcasAutosService;

        public MarcasAutosController(IMarcasAutosService marcasAutosService)
        {
            _marcasAutosService = marcasAutosService;
        }

        /// <summary>
        /// Obtiene todas las marcas de autos.
        /// </summary>
        /// <returns>Listado de marcas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MarcasAutosDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MarcasAutosDto>>> GetAll()
        {
            var vehicles = await _marcasAutosService.GetAllAsync();
            return new OkObjectResult(vehicles);
        }
        
    }
}
