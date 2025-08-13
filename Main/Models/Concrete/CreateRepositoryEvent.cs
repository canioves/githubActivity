using Main.Models.Abstract;

namespace Main.Models
{
    public class CreateRepositoryEvent : BaseCreateEvent
    {
        public string CreateType => "Repository";

        public override string PrintMessage()
        {
            return $"Created new repository: {RepoName}";
        }
    }
}
