namespace Main.Models.Abstract
{
    public abstract class BaseCreateEvent : IEvent
    {
        public string Type => "CreateEvent";
        public string Ref { get; set; }
        public string RefType { get; set; }
        public string RepoName { get; set; }
        public List<Commit> Commits { get; set; }

        public abstract string Accept(IEventVisitor visitor);
    }
}
