using Main.DTOs.Events;
using Main.Models;
using Main.Models.Concrete;
using Main.Services.Factories;

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
                IssueCommentEventDTO issueCommentDto => IssueCommentEventFactory.Create(
                    issueCommentDto
                ),
                _ => throw new NotSupportedException("Unknown type of event"),
            };
        }
    }
}
