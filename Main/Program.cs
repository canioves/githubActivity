using Main.Clients;
using Main.Models;
using Main.Models.Abstract;
using Main.Services;
using Main.Services.Formatters;
using Microsoft.Extensions.Configuration;

namespace Main;

class Program
{
    static async Task Main(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        AppSettings appSettings = config.Get<AppSettings>();

        Console.WriteLine("GitHub username: ");
        string username = Console.ReadLine();

        IClient client = new GithubClient(appSettings);
        IEventVisitor formatter = new EventFormatter();
        GithubService service = new GithubService(client, formatter);

        IEnumerable<IEvent> events = await service.GetEventsAsync(username);
        IEnumerable<string> eventsText = service.GetEventsText(events);
        foreach (string text in eventsText)
        {
            Console.WriteLine(text);
        }
    }
}
