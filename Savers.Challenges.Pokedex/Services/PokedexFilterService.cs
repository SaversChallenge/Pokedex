#nullable enable

using Savers.Challenges.Pokedex.Interfaces;
using Savers.Challenges.Pokedex.Models;
using Savers.Challenges.Pokedex.Models.Queries;

namespace Savers.Challenges.Pokedex.Services
{
    public class PokedexFilterService : IPokedexFilter
    {
        private readonly ILogger<PokedexFilterService> _logger;
        public PokedexFilterService(ILogger<PokedexFilterService> logger)
        {
            _logger = logger;
        }

        public void Filter(ref IEnumerable<PokedexEntry> pokedexEntries, PokedexQuery pokedexQuery)
        {
            if (pokedexEntries == null)
            {
                throw new ArgumentNullException(nameof(pokedexEntries));
            }

            if (pokedexQuery == null)
            {
                throw new ArgumentNullException(nameof(pokedexQuery));
            }

            if (pokedexQuery.Types != null)
            {
                _logger.LogDebug("PokedexFilterService::Filter: filtering results by pokemon type(s)");

                pokedexEntries = pokedexEntries.Where(entry => entry.Types != null && pokedexQuery.Types.Intersect(entry.Types).Count() == pokedexQuery.Types.Count());
            }
        }
    }
}
