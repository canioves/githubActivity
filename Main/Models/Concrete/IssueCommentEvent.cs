using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class IssueCommentEvent : IEvent
    {
        public string Type => "IssueCommentEvent";
        public string ActionType { get; set; }
        public string RepoName { get; set; }
        public string IssueTitle { get; set; }
        public string IssueBody { get; set; }
        public string IssueState { get; set; }

        public string Accept(IEventVisitor visitor) => visitor.Visit(this);
    }
}
