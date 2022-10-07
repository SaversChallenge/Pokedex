using Savers.Challenges.Pokedex.Interfaces;
using Savers.Challenges.Pokedex.Models;
using Savers.Challenges.Pokedex.Models.Queries;

namespace Savers.Challenges.Pokedex.Services
{
    public class PokedexService : IHandlePokedexEntries
    {
        private readonly ILogger<PokedexService> _logger;
        private readonly IGetPokedexEntries _pokedexRepo;
        private readonly IPokedexFilter _pokedexFilter;

        public PokedexService(ILogger<PokedexService> logger, IGetPokedexEntries pokedexRepo, IPokedexFilter pokedexFilter)
        {
            _logger = logger;
            _pokedexRepo = pokedexRepo;
            _pokedexFilter = pokedexFilter;
        }

        public async Task<IEnumerable<PokedexEntry>> GetPokedexEntries(PokedexQuery pokedexQuery)
        {
            var pokedexEntries = await _pokedexRepo.GetPokedexEntries();

            _pokedexFilter.Filter(ref pokedexEntries, pokedexQuery);

            return pokedexEntries;
        }
    }
}
