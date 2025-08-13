using Main.Clients;
using Main.DTOs.Events;
using Main.Models;

namespace Main.Services
{
    public class GithubService
    {
        private IClient _client;

        public GithubService(IClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<IEvent>> GetEventsAsync(string username)
        {
            List<BaseEventDTO> dtos = await _client.GetBaseEventDTOs(username);
            IEnumerable<IEvent> events = dtos.Select(GithubEventFactory.Create);
            return events;
        }
    }
}
