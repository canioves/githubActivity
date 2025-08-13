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

        public async Task<string> GetEventsRawJsonAsync(string username)
        {
            string url = $"/users/{username}/events";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}
