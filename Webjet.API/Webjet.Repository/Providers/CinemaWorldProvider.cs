using Webjet.Entities;
using Webjet.Repository.Clients;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Class CinemaWorldProvider
    /// </summary>
    public class CinemaWorldProvider : MovieProviderBase
    {
        public CinemaWorldProvider(string url, IMovieProviderClient<MoviesCollection> moviesProviderClient,
                                               IMovieProviderClient<MovieDetails> movieDetailsProviderClient) 
            : base(url, Provider.cinemaworld, moviesProviderClient, movieDetailsProviderClient)
        {

        }
    }
}
