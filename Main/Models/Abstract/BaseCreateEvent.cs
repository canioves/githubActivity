using Main.Models.Concrete;

namespace Main.Models.Abstract
{
    public abstract class BaseCreateEvent : IEvent
    {
        public string Type => "CreateEvent";
        public string BranchName { get; set; }
        public string SubType { get; }
        public string RepoName { get; set; }
        public List<Commit> Commits { get; set; }

        public abstract string Accept(IEventVisitor visitor);
    }
}
