using System;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Interface ICacheProvider
    /// </summary>
    public interface ICacheProvider
    {
        T GetCacheEntry<T>(string key, Func<T> get)
            where T : class;
    }
}
