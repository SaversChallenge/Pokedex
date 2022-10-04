using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Models
{
    public class PokemonStats
    {
        [JsonPropertyName("hitPoints")]
        public int HitPoints { get; set; }
        [JsonPropertyName("attack")]
        public int Attack { get; set; }
        [JsonPropertyName("defense")]
        public int Defense { get; set; }
        [JsonPropertyName("speed")]
        public int Speed { get; set; }
    }
}
