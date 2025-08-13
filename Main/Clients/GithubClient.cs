using System.Text.Json;
using Main.DTOs.Events;
using Main.Utils;

namespace Main.Clients
{
    public class GithubClient : IClient
    {
        private static readonly JsonSerializerOptions _jsonOptions = JsonSettings.Default;
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public GithubClient(AppSettings settings)
        {
            _settings = settings;
            _httpClient = new HttpClient { BaseAddress = new Uri(settings.BaseUrl) };

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GithubActivityApp/1.0");
        }

        private async Task<string> GetEventsJsonAsync(string username)
        {
            string url = $"/users/{username}/events";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return json;
        }

        public async Task<List<BaseEventDTO>> GetBaseEventDTOs(string username)
        {
            string json = await GetEventsJsonAsync(username);

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            List<BaseEventDTO> baseDtos = [];

            foreach (JsonElement element in root.EnumerateArray())
            {
                BaseEventDTO eventDto = JsonSerializer.Deserialize<BaseEventDTO>(
                    element,
                    _jsonOptions
                );
                baseDtos.Add(eventDto);
            }
            return baseDtos;
        }
    }
}
