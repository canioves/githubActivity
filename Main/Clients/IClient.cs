using Main.Models;

namespace Main.Clients
{
    public interface IClient
    {
        Task<string> GetEventsRawJsonAsync(string username);
    }
}
