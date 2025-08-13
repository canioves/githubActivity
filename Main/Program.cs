using Main.Clients;
using Main.Models;
using Main.Services;
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
        GithubService service = new GithubService(client);

        IEnumerable<IEvent> events = await service.GetEventsAsync(username);

        foreach (IEvent @event in events)
        {
            Console.WriteLine(@event.PrintMessage());
        }
    }
}
