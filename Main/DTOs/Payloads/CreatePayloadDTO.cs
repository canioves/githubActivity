namespace Main.DTOs.Payloads
{
    public class CreatePayloadDTO
    {
        public string Ref { get; set; }
        public string RefType { get; set; }
        public string MasterBranch { get; set; }
        public string Description { get; set; }
        public string PusherType { get; set; }
    }
}
