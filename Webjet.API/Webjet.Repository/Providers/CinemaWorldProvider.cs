using Webjet.Entities;
using Webjet.Repository.Clients;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Class CinemaWorldProvider
    /// </summary>
    public class CinemaWorldProvider : MovieProviderBase
    {
        public CinemaWorldProvider(string url, IMovieProviderClient moviesProviderClient, 
                                               ICacheProvider cacheProvider) 
            : base(url, Provider.cinemaworld, moviesProviderClient, cacheProvider)
        {

        }
    }
}
