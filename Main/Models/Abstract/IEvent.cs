using Main.Models.Abstract;

namespace Main.Models
{
    public interface IEvent
    {
        public string Type { get; }
        public string RepoName { get; set; }

        public string Accept(IEventVisitor visitor);
    }
}
