using System.Text.Json;
using Main.DTOs;
using Main.DTOs.Events;
using Main.Models;
using Main.Models.Abstract;
using Main.Utils;

namespace Main.Services
{
    public static class GithubEventFactory
    {
        private static readonly JsonSerializerOptions _settings = JsonSettings.Default;

        public static IEvent Create(BaseEventDTO baseDto, string json)
        {
            switch (baseDto.Type)
            {
                case "CreateEvent":
                    CreateEventDTO createEventDto = JsonSerializer.Deserialize<CreateEventDTO>(
                        json,
                        _settings
                    );

                    IEvent createEvent = CreateEventFactory.Create(createEventDto);
                    return createEvent;

                case "PushEvent":
                    PushEventDTO pushEventDto = JsonSerializer.Deserialize<PushEventDTO>(
                        json,
                        _settings
                    );

                    List<Commit> commits = [];

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
