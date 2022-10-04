using Savers.Challenges.Pokedex.Models;

namespace Savers.Challenges.Pokedex.Interfaces
{
    public interface IGetPokedexEntries
    {
        Task<IEnumerable<PokedexEntry>> GetPokedexEntries();
    }
}
