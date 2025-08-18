namespace Main.Models.Abstract
{
    public abstract class BaseIssueCommentEvent : IEvent
    {
        public string Type => "IssueCommentEvent";
        public abstract string SubType { get;}
        public string ActionType { get; set; }
        public string RepoName { get; set; }
        public abstract string Accept(IEventVisitor visitor);
    }
}
