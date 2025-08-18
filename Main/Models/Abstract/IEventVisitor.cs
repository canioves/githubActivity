using Main.Models.Concrete;

namespace Main.Models.Abstract
{
    public interface IEventVisitor
    {
        string Visit(PushEvent pushEvent);
        string Visit(CreateBranchEvent createBranchEvent);
        string Visit(CreateRepositoryEvent createRepositoryEvent);
        string Visit(IssueCommentEvent issueCommentEvent);
        string Visit(PullRequestCommentEvent pullRequestCommentEvent);
    }
}
