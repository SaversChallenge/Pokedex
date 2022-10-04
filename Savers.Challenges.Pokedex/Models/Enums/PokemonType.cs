using System.Text.Json.Serialization;

namespace Savers.Challenges.Pokedex.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PokemonType
    {
        Unknown,
        Normal,
        Fighting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Electric,
        Psychic,
        Ice,
        Dragon,
        Dark,
        Fairy
    }
}
