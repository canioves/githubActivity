namespace Main.DTOs.Payloads
{
    public class PushPayloadDTO
    {
        public int RepositoryId { get; set; }
        public int PushId { get; set; }
        public int Size { get; set; }
        public int DistinctSize { get; set; }
        public string Ref { get; set; }
        public string Head { get; set; }
        public string Before { get; set; }
        public IEnumerable<CommitDTO> Commits { get; set; }
    }
}
