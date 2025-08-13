using Main.DTOs.Events;
using Main.Models;

namespace Main.Services.Factories
{
    public interface IEventFactory
    {
        IEvent Create(BaseEventDTO dto);
    }
}
