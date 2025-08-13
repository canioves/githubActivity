using System.Text.Json.Serialization;
using Main.DTOs.Payloads;

namespace Main.DTOs.Events
{
    public class CreateEventDTO : BaseEventDTO
    {
        [JsonPropertyName("payload")]
        public CreatePayloadDTO Payload { get; set; }
    }
}
