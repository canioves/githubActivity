using System.Text.Json.Serialization;
using Main.DTOs.Payloads;

namespace Main.DTOs.Events
{
    public class PushEventDTO : BaseEventDTO
    {
        [JsonPropertyName("payload")]
        public PushPayloadDTO Payload { get; set; }
    }
}
