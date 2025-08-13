using System.Text;

namespace Main.Models
{
    public class PushEvent : IEvent
    {
        public string Type => "PushEvent";
        public string RepoName { get; set; }
        public List<Commit> Commits { get; set; }

        public string PrintMessage()
        {
            int commitCount = Commits.Count;
            string message = $"Pushed {commitCount} commits to {RepoName}:\n";
            StringBuilder sb = new(message);

            foreach (Commit commit in Commits)
            {
                sb.AppendLine($"\t- \"{commit.Message}\" by {commit.Author} (SHA: {commit.Sha})");
            }

            return sb.ToString();
        }
    }
}
