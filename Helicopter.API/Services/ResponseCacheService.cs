using Helicopter.API.Services.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Helicopter.API.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public  async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive)
        {
            if(response == null)
            {
                return;
            }

            var serializedResponse = JsonSerializer.Serialize(response);
            await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeLive
            });
        }

        public async Task<string?> GetCacheResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
            return String.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }
    }
}
