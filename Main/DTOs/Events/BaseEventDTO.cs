using System.Text.Json.Serialization;

namespace Main.DTOs.Events
{
    public abstract class BaseEventDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("actor")]
        public ActorDTO Actor { get; set; }

        [JsonPropertyName("repo")]
        public RepoDTO Repo { get; set; }

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
