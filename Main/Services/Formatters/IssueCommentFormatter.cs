using Main.Models;
using Main.Models.Abstract;
using Main.Models.Concrete;

namespace Main.Services.Formatters
{
    public class IssueCommentFormatter : IEventFormatter
    {
        public string Format(IEvent evnt)
        {
            BaseIssueCommentEvent issueCommentEvent = evnt as BaseIssueCommentEvent;

            string target = issueCommentEvent.IsPullRequest ? "PR" : "issue";
            string action = issueCommentEvent.ActionType;

            return issueCommentEvent switch
            {
                IssueCommentEvent issue when action == "created" =>
                    $"New comment on issue \"{issue.IssueTitle}\": {issue.IssueBody}.",
                IssueCommentEvent issue when action == "edited" =>
                    $"Edited comment on issue \"{issue.IssueTitle}\": {issue.IssueBody}.\nEdited: {issue.IssueLastBody}.",
                IssueCommentEvent issue when action == "deleted" =>
                    $"Deleted comment on issue \"{issue.IssueTitle}\".",
                PullRequestCommentEvent pr when action == "created" =>
                    $"New comment on PR \"{pr.PullRequestTitle}\": {pr.PullRequestBody}.",
                PullRequestCommentEvent pr when action == "edited" =>
                    $"Edited comment on PR \"{pr.PullRequestTitle}\": {pr.PullRequestBody}.\nEdited: {pr.PullRequestLastBody}.",
                PullRequestCommentEvent pr when action == "deleted" =>
                    $"Deleted comment on PR \"{pr.PullRequestTitle}\".",
                _ => throw new ArgumentException($"Unknown type of action: {action}"),
            };
        }
    }
}
