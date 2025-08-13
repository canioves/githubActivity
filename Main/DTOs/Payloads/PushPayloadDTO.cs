using System.Text.Json.Serialization;

namespace Main.DTOs.Payloads
{
    public class PushPayloadDTO
    {
        [JsonPropertyName("repository_id")]
        public long RepositoryId { get; set; }

        [JsonPropertyName("push_id")]
        public long PushId { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("distinct_size")]
        public int DistinctSize { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("head")]
        public string Head { get; set; }

        [JsonPropertyName("before")]
        public string Before { get; set; }

        [JsonPropertyName("commits")]
        public IEnumerable<CommitDTO> Commits { get; set; }
    }
}
