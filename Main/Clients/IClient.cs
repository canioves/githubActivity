using Main.Models;

namespace Main.Clients
{
    public interface IClient
    {
        Task<IEnumerable<IEvent>> GetUserEventsAsync(string username);
        Task<string> GetUserEventsJsonAsync(string username);
    }
}
