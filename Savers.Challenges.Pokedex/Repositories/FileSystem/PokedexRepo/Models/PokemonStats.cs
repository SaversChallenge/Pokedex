using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Repositories.FileSystem.PokedexRepo.Models
{
    public class PokemonStats
    {
        [JsonPropertyName("HP")]
        public int HitPoints { get; set; }
        [JsonPropertyName("Attack")]
        public int Attack { get; set; }
        [JsonPropertyName("Defense")]
        public int Defense { get; set; }
        [JsonPropertyName("Speed")]
        public int Speed { get; set; }
    }
}
