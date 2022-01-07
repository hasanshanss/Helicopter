using Helicopter.DAL.Entities;
using System.Text.Json.Serialization;

namespace Helicopter.ConsoleClient.Resources
{
    public class Game
    {
        public int Id { get; set; }

        [JsonPropertyName("game-name")]
        public string? GameName { get; set; }

        [JsonPropertyName("year")]
        public string? Year { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? DisplayName { get; set; }

        public int Views { get; set; }

        public int GameCategoryId { get; set; }

        public byte[]? Timestamp { get; set; }
        public GameCategory? GameCategoryNavigation { get; set; }


    }
}
