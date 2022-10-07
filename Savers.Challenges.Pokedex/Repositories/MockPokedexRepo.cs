using Savers.Challenges.Pokedex.Interfaces;
using Savers.Challenges.Pokedex.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Repositories
{
    public class MockPokedexRepo : IGetPokedexEntries
    {
        private readonly JsonSerializerOptions _options;

        public MockPokedexRepo()
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
            var pokedexEntries = await JsonSerializer.DeserializeAsync<List<PokedexEntry>>(openStream, _options);

            if (pokedexEntries == null)
            {
                throw new Exception("Failure to get pokedex entries from file system");
            }

            return pokedexEntries;
        }
    }
}
