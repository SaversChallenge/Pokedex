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
        private readonly IGetPokedexEntries _getPokedexEntries;
        private readonly IPokedexFilter _pokedexFilter;
        public PokedexController(ILogger<PokedexController> logger, IGetPokedexEntries getPokedexEntries, IPokedexFilter pokedexFilter)
        {
            _logger = logger;
            _getPokedexEntries = getPokedexEntries;
            _pokedexFilter = pokedexFilter;
        }

        [HttpGet(Name = "GetPokedex")]
        public async Task<ActionResult<IEnumerable<PokedexEntry>>> Get([FromQuery] PokedexQuery pokedexQuery)
        {
            try
            {
                var pokedexEntries = await _getPokedexEntries.GetPokedexEntries();

                _pokedexFilter.Filter(ref pokedexEntries, pokedexQuery);

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