using Main.DTOs.Events;
using Main.Models;
using Main.Models.Concrete;

namespace Main.Services.Factories
{
    public static class IssueCommentEventFactory
    {
        public static IEvent Create(IssueCommentEventDTO dto)
        {
            if (dto.Payload.Issue.PullRequest is not null)
            {
                return new PullRequestCommentEvent
                {
                    ActionType = dto.Payload.Action,
                    PullRequestBody = dto.Payload.Issue.Body,
                    PullRequestLastBody =
                        dto.Payload.Action == "edited" ? dto.Payload.Issue.Changes.Body.From : "",
                    PullRequestState = dto.Payload.Issue.State,
                    PullRequestTitle = dto.Payload.Issue.Title,
                    RepoName = dto.Repo.Name,
                };
            }
            else
            {
                return new IssueCommentEvent
                {
                    ActionType = dto.Payload.Action,
                    IssueBody = dto.Payload.Issue.Body,
                    IssueLastBody =
                        dto.Payload.Action == "edited" ? dto.Payload.Issue.Changes.Body.From : "",
                    IssueState = dto.Payload.Issue.State,
                    IssueTitle = dto.Payload.Issue.Title,
                    RepoName = dto.Repo.Name,
                };
            }
        }
    }
}
