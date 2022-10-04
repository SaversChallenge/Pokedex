using Savers.Challenges.Pokedex.Models;
using Savers.Challenges.Pokedex.Models.Queries;

namespace Savers.Challenges.Pokedex.Interfaces
{
    public interface IPokedexFilter
    {
        void Filter(ref IEnumerable<PokedexEntry> pokedexEntries, PokedexQuery pokedexQuery);
    }
}
