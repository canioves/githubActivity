using Main.DTOs.Payloads;

namespace Main.DTOs.Events
{
    public class PushEventDTO : BaseEventDTO
    {
        public PushPayloadDTO Payload { get; set; }
    }
}
