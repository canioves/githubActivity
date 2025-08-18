using Main.Models;
using Main.Models.Abstract;

namespace Main.Services.Formatters
{
    public class IssueCommentFormatter : IEventFormatter
    {
        public string Format(IEvent evnt)
        {
            BaseIssueCommentEvent issueCommentEvent = evnt as BaseIssueCommentEvent;

            return issueCommentEvent.SubType switch
            {
                "IssueCommentEvent" => $"",
            };
        }
    }
}
