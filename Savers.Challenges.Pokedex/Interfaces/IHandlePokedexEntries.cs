using Savers.Challenges.Pokedex.Models;
using Savers.Challenges.Pokedex.Models.Queries;

namespace Savers.Challenges.Pokedex.Interfaces
{
    public interface IHandlePokedexEntries
    {
        Task<IEnumerable<PokedexEntry>> GetPokedexEntries(PokedexQuery pokedexQuery);
    }
}
