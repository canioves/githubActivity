using Main.DTOs.Payloads;

namespace Main.DTOs.Events
{
    public class CreateEventDTO : BaseEventDTO
    {
        public CreatePayloadDTO Payload { get; set; }
    }
}
