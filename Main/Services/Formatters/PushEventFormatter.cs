using Main.Models;

namespace Main.Services.Formatters
{
    public class PushEventFormatter : IEventFormatter
    {
        public string Format(IEvent evnt)
        {
            PushEvent pushEvent = evnt as PushEvent;

            List<string> commitMessages =
            [
                .. pushEvent.Commits.Select(x => $"\"{x.Message}\" by {x.Author} (SHA: {x.Sha})"),
            ];
            string formatedCommitText = ListFormatter.ToBulletList(commitMessages);

            return $"Pushed {pushEvent.Commits.Count} new commits to {pushEvent.RepoName}:\n{formatedCommitText}";
        }
    }
}
