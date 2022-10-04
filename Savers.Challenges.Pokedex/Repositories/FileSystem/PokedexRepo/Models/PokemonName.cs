using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Repositories.FileSystem.PokedexRepo.Models
{
    public class PokemonName
    {
        [JsonPropertyName("english")]
        public string? English { get; set; }
        [JsonPropertyName("japanese")]
        public string? Japanese { get; set; }
        [JsonPropertyName("chinese")]
        public string? Chinese { get; set; }
        [JsonPropertyName("french")]
        public string? French { get; set; }
    }
}
