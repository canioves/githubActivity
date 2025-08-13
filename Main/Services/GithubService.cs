using System.Text.Json;
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
            string json = await _client.GetEventsRawJsonAsync(username);
            List<IEvent> events = [];

            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            foreach (JsonElement jsonEvent in root.EnumerateArray())
            {
                string eventType = jsonEvent.GetProperty("type").GetString();
                string eventRawJson = jsonEvent.GetRawText();

                IEvent eventModel = GithubEventFactory.CreateEvent(eventType, eventRawJson);
                events.Add(eventModel);
            }
            return events;
        }
    }
}
