using Helicopter.ConsoleClient.Resources;

namespace Helicopter.ConsoleClient.HttpClients.Abstractions
{
    interface IGameClient
    {
        Task<IEnumerable<Game>> GetGameAsync();
        Task<int> GetGameCountAsync(); 

    }
}
