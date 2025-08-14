using Main.Models;

namespace Main.Services.Formatters
{
    public interface IEventFormatter
    {
        string Format(IEvent evnt);
    }
}
