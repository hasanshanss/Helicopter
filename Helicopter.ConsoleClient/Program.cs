using Helicopter.ConsoleClient.HttpClients;
using Helicopter.ConsoleClient.HttpClients.Abstractions;
using Helicopter.ConsoleClient.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

using IHost host = CreateHostBuilder(args).Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var newsAgencyClient = provider.GetRequiredService<IGameClient>();

foreach (Game game in await newsAgencyClient.GetGameAsync())
{
    Console.WriteLine(game.GameName);
    Console.WriteLine(game.Year);
}

await host.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
                   services.AddHttpClient<IGameClient, GameClient>()
                           .AddTransientHttpErrorPolicy(
                       p => p.WaitAndRetryAsync(new[]
                       {
                            TimeSpan.FromSeconds(1),
                            TimeSpan.FromSeconds(5),
                            TimeSpan.FromSeconds(10)
                       })));


