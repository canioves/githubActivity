using Main.Models;

namespace Main.Clients
{
    public class GithubClient : IClient
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public GithubClient(AppSettings settings)
        {
            _settings = settings;
            _httpClient = new HttpClient { BaseAddress = new Uri(settings.BaseUrl) };

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("GithubActivityApp/1.0");
        }

        public Task<IEnumerable<IEvent>> GetUserEventsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetUserEventsJsonAsync(string username)
        {
            string url = $"/users/{username}/events";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
