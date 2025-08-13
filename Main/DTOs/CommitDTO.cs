using System.Text.Json.Serialization;

namespace Main.DTOs
{
    public class CommitDTO
    {
        [JsonPropertyName("sha")]
        public string Sha { get; set; }

        [JsonPropertyName("author")]
        public AuthorDTO Author { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("distinct")]
        public bool Distinct { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class AuthorDTO
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
