using Main.Clients;
using Main.DTOs.Events;
using Main.Models;
using Main.Models.Abstract;
using Main.Services.Factories;
using Main.Services.Formatters;

namespace Main.Services
{
    public class GithubService
    {
        private IClient _client;
        private IEventFactory _factory;
        private IEventVisitor _formatter;

        public GithubService(IClient client, IEventVisitor formatter)
            : this(client, formatter, new GithubEventFactoryWrapper()) { }

        public GithubService(IClient client, IEventVisitor formatter, IEventFactory factory)
        {
            _client = client;
            _formatter = formatter;
            _factory = factory;
        }

        public async Task<IEnumerable<IEvent>> GetEventsAsync(string username)
        {
            List<BaseEventDTO> dtos = await _client.GetBaseEventDTOs(username);
            IEnumerable<IEvent> events = dtos.Select(_factory.Create);
            return events;
        }

        public IEnumerable<string> GetEventsText(IEnumerable<IEvent> events)
        {
            return events.Select(x => x.Accept(_formatter));
        }
    }
}
