using Main.Models.Abstract;
using Main.Models.Concrete;

namespace Main.Services.Formatters
{
    public class MainEventFormater : IEventVisitor
    {
        private readonly CreateEventFormatter _createFormater = new CreateEventFormatter();
        private readonly PushEventFormatter _pushFormater = new PushEventFormatter();

        public string Visit(PushEvent pushEvent) => _pushFormater.Format(pushEvent);

        public string Visit(CreateBranchEvent createBranchEvent) =>
            _createFormater.Format(createBranchEvent);

        public string Visit(CreateRepositoryEvent createRepositoryEvent) =>
            _createFormater.Format(createRepositoryEvent);

        public string Visit(IssueCommentEvent issueCommentEvent)
        {
            return $"Issue \"{issueCommentEvent.IssueTitle}\" was {issueCommentEvent.ActionType}.\nBody: {issueCommentEvent.IssueBody}\nCurrent state - {issueCommentEvent.IssueState}";
        }
    }
}
