using Main.DTOs.Events;
using Main.Models;

namespace Main.Services.Factories
{
    public class GithubEventFactoryWrapper : IEventFactory
    {
        public IEvent Create(BaseEventDTO dto)
        {
            return GithubEventFactory.Create(dto);
        }
    }
}
