using Savers.Challenges.Pokedex.Models.Enums;
using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Repositories.FileSystem.PokedexRepo.Models
{
    public class PokedexEntry
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public PokemonName? Name { get; set; }
        [JsonPropertyName("type")]
        public List<PokemonType>? Types { get; set; }
        [JsonPropertyName("base")]
        public PokemonStats? BaseStats { get; set; }
    }
}
