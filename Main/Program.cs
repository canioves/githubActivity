using Main.Clients;
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
        string json = await client.GetUserEventsJsonAsync(username);

        Console.WriteLine(json);
    }
}
