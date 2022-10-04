using Savers.Challenges.Pokedex.Interfaces;
using Savers.Challenges.Pokedex.Models;
using Repo = Savers.Challenges.Pokedex.Repositories.FileSystem.PokedexRepo.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Repositories.FileSystem.PokedexRepo
{
    public class PokedexRepo : IGetPokedexEntries
    {
        private readonly JsonSerializerOptions _options;

        public PokedexRepo()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
        }

        public async Task<IEnumerable<PokedexEntry>> GetPokedexEntries()
        {
            using FileStream openStream = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "data", "pokedex.json"));
            var pokedexEntries = await JsonSerializer.DeserializeAsync<List<Repo.PokedexEntry>>(openStream, _options);

            if (pokedexEntries == null)
            {
                throw new Exception("Failure to get pokedex entries from file system");
            }

            return pokedexEntries.Select(entry => new PokedexEntry
            {
                Id = entry.Id,
                Name = entry.Name?.English,
                Types = entry.Types,
                BaseStats = new PokemonStats
                {
                    HitPoints = entry.BaseStats?.HitPoints ?? 0,
                    Attack = entry.BaseStats?.Attack ?? 0,
                    Defense = entry.BaseStats?.Defense ?? 0,
                    Speed = entry.BaseStats?.Speed ?? 0
                }
            });
        }
    }
}
