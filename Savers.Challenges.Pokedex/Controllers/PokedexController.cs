using Microsoft.AspNetCore.Mvc;
using Savers.Challenges.Pokedex.Interfaces;
using Savers.Challenges.Pokedex.Models;
using Savers.Challenges.Pokedex.Models.Queries;

namespace Savers.Challenges.Pokedex.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("pokedex")]
    public class PokedexController : ControllerBase
    {
        private readonly ILogger<PokedexController> _logger;
        private readonly IHandlePokedexEntries _pokedexService;
        public PokedexController(ILogger<PokedexController> logger, IHandlePokedexEntries pokedexService)
        {
            _logger = logger;
            _pokedexService = pokedexService;
        }

        [HttpGet(Name = "GetPokedex")]
        public async Task<ActionResult<IEnumerable<PokedexEntry>>> Get([FromQuery] PokedexQuery pokedexQuery)
        {
            try
            {
                var pokedexEntries = await _pokedexService.GetPokedexEntries(pokedexQuery);

                return Ok(pokedexEntries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PokedexController::Get: threw an unknown exception");
                return StatusCode(500);
            }
        }
    }
}