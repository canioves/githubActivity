using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class PullRequestCommentEvent : BaseIssueCommentEvent
    {
        public override bool IsPullRequest => true;
        public string PullRequestTitle { get; set; }
        public string PullRequestBody { get; set; }
        public string PullRequestState { get; set; }

        public override string Accept(IEventVisitor visitor) => visitor.Visit(this);
    }
}
