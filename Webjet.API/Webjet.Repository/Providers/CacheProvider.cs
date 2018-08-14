using Microsoft.Extensions.Caching.Memory;
using System;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Class CacheProvider
    /// </summary>
    public class CacheProvider : ICacheProvider
    {
        IMemoryCache _cache;
        int _cacheDurationInHours;        

        public CacheProvider(IMemoryCache memoryCache, int cacheDurationInHours)
        {
            _cache = memoryCache;
            _cacheDurationInHours = cacheDurationInHours;
        }

        public T GetCacheEntry<T>(string key, Func<T> get)
            where T : class
        {
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(_cacheDurationInHours);

                return get();
            });
        }
    }
}
