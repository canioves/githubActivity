namespace Main.Models
{
    public class CreateEvent : IEvent
    {
        public string Type => "CreateEvent";
        public string RepoName { get; set; }

        public string PrintMessage()
        {
            return $"Created new repository: {RepoName}";
        }
    }
}
