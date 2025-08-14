using Main.Models;
using Main.Models.Abstract;

namespace Main.Services.Formatters
{
    public class CreateEventFormatter : IEventFormatter
    {
        private readonly Dictionary<string, Func<BaseCreateEvent, string>> _subFormatters;

        public CreateEventFormatter()
        {
            _subFormatters = new Dictionary<string, Func<BaseCreateEvent, string>>
            {
                { "repository", x => $"Created new repo {x.RepoName}\n" },
                { "branch", x => $"Created new branch \"{x.Ref}\" in {x.RepoName}\n" },
            };
        }

        public string Format(IEvent evnt)
        {
            BaseCreateEvent createEvent = evnt as BaseCreateEvent;

            if (
                _subFormatters.TryGetValue(
                    createEvent.RefType,
                    out Func<BaseCreateEvent, string> formatter
                )
            )
            {
                return formatter(createEvent);
            }
            return $"Unknown CreateEvent type: {createEvent.RefType}";
        }
    }
}
