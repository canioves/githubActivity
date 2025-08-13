using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class CreateBranchEvent : BaseCreateEvent
    {
        public string CreateType => "Branch";

        public override string PrintMessage()
        {
            return $"Created new branch {Ref} in {RepoName}";
        }
    }
}
