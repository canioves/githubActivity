using Main.DTOs.Events;
using Main.Models;
using Main.Models.Concrete;

namespace Main.Services
{
    public static class GithubEventFactory
    {
        public static IEvent Create(BaseEventDTO baseDto)
        {
            return baseDto switch
            {
                PushEventDTO pushDto => new PushEvent
                {
                    RepoName = pushDto.Repo.Name,
                    Commits =
                    [
                        .. pushDto.Payload.Commits.Select(x => new Commit
                        {
                            Sha = x.Sha,
                            Author = x.Author.Name,
                            Message = x.Message,
                        }),
                    ],
                },
                CreateEventDTO createDto => CreateEventFactory.Create(createDto),
                IssueCommentEventDTO issueCommentDto => new IssueCommentEvent
                {
                    ActionType = issueCommentDto.Payload.Action,
                    IssueBody = issueCommentDto.Payload.Issue.Body,
                    IssueState = issueCommentDto.Payload.Issue.State,
                    IssueTitle = issueCommentDto.Payload.Issue.Title,
                    RepoName = issueCommentDto.Repo.Name,
                },
                _ => throw new NotSupportedException("Unknown type of event"),
            };
        }
    }
}
