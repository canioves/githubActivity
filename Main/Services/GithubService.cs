using Main.Clients;
using Main.DTOs.Events;
using Main.Models;
using Main.Services.Factories;

namespace Main.Services
{
    public class GithubService
    {
        private IClient _client;
        private IEventFactory _factory;

        public GithubService(IClient client)
            : this(client, new GithubEventFactoryWrapper()) { }

        public GithubService(IClient client, IEventFactory factory)
        {
            _client = client;
            _factory = factory;
        }

        public async Task<IEnumerable<IEvent>> GetEventsAsync(string username)
        {
            List<BaseEventDTO> dtos = await _client.GetBaseEventDTOs(username);
            IEnumerable<IEvent> events = dtos.Select(_factory.Create);
            return events;
        }
    }
}
