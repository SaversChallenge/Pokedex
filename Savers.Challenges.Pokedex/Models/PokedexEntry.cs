using Savers.Challenges.Pokedex.Models.Enums;
using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Models
{
    public class PokedexEntry
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("type")]
        public List<PokemonType>? Types { get; set; }
        [JsonPropertyName("baseStats")]
        public PokemonStats? BaseStats { get; set; }
    }
}
