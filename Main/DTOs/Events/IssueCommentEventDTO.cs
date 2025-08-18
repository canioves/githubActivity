using System.Text.Json.Serialization;
using Main.DTOs.Payloads;

namespace Main.DTOs.Events
{
    public class IssueCommentEventDTO : BaseEventDTO
    {
        [JsonPropertyName("payload")]
        public IssueCommentPayloadDTO Payload { get; set; }
    }
}
