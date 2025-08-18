using Main.Models.Abstract;

namespace Main.Models.Concrete
{
    public class CreateRepositoryEvent : BaseCreateEvent
    {
        public string CreateType => "Repository";

        public override string Accept(IEventVisitor visitor) => visitor.Visit(this);
    }
}
