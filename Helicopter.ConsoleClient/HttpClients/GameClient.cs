using Helicopter.ConsoleClient.Extensions;
using Helicopter.ConsoleClient.Resources;
using Helicopter.ConsoleClient.HttpClients.Abstractions;
using System.Net.Http.Headers;

namespace Helicopter.ConsoleClient.HttpClients
{
    class GameClient : IGameClient
    {
        private const string BaseUrl = "https://localhost:44359/";
        private HttpClient _client;

        public GameClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(BaseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Game>> GetGameAsync()
        {
            HttpResponseMessage response =  await _client.GetAsync(BaseUrl + "api/Game");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Game[]>();
            }

            return null;
        }

        public async Task<int> GetGameCountAsync()
        {
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + "api/Game/Count");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }

            return 0;
        }
    }
}
