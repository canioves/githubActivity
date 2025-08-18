using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class PushEvent : IEvent
    {
        public string Type => "PushEvent";
        public string RepoName { get; set; }
        public List<Commit> Commits { get; set; }

        public string Accept(IEventVisitor visitor) => visitor.Visit(this);
    }
}
