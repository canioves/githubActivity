using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class CreateBranchEvent : BaseCreateEvent
    {
        public string CreateType => "Branch";

        public override string Accept(IEventVisitor visitor) => visitor.Visit(this);
    }
}
