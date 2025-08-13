using Main.DTOs.Events;

namespace Main.Clients
{
    public interface IClient
    {
        Task<List<BaseEventDTO>> GetBaseEventDTOs(string username);
    }
}
