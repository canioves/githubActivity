using System.Text.Json;
using System.Text.Json.Nodes;
using Main.DTOs;
using Main.DTOs.Events;
using Main.DTOs.Payloads;
using Main.Models;

namespace Main.Services
{
    public static class GithubEventFactory
    {
        public static IEvent CreateEvent(string type, string json)
        {
            switch (type)
            {
                case "CreateEvent":
                    CreateEventDTO createEventDto = JsonSerializer.Deserialize<CreateEventDTO>(
                        json
                    );

                    CreateEvent createEvent = new CreateEvent
                    {
                        RepoName = createEventDto.Repo.Name,
                    };
                    return createEvent;

                case "PushEvent":
                    PushEventDTO pushEventDto = JsonSerializer.Deserialize<PushEventDTO>(json);

                    List<Commit> commits = [];

                    // TODO: trace bugs with deserialization
                    foreach (CommitDTO commitDto in pushEventDto.Payload.Commits)
                    {
                        Commit commit = new Commit
                        {
                            Sha = commitDto.Sha,
                            Message = commitDto.Message,
                            Author = commitDto.Author.Name,
                        };
                        commits.Add(commit);
                    }

                    PushEvent pushEvent = new PushEvent
                    {
                        RepoName = pushEventDto.Repo.Name,
                        Commits = commits,
                    };
                    return pushEvent;
                default:
                    throw new ArgumentException("Unknown type of event");
            }
        }
    }
}
