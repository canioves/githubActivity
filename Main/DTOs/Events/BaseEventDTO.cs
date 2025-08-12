namespace Main.DTOs.Events
{
    public abstract class BaseEventDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public ActorDTO Actor { get; set; }
        public RepoDTO Repo { get; set; }
        public bool Public { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
