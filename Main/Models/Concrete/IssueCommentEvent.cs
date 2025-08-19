using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class IssueCommentEvent : BaseIssueCommentEvent
    {
        public override bool IsPullRequest => false;
        public string IssueTitle { get; set; }
        public string IssueBody { get; set; }
        public string IssueState { get; set; }
        public string IssueLastBody { get; set; }

        public override string Accept(IEventVisitor visitor) => visitor.Visit(this);
    }
}
