using Webjet.Entities;
using Webjet.Repository.Clients;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// FilmWorldProvider
    /// </summary>
    public class FilmWorldProvider : MovieProviderBase
    {
        public FilmWorldProvider(string url, IMovieProviderClient<MoviesCollection> moviesProviderClient,
                                             IMovieProviderClient<MovieDetails> movieDetailsProviderClient) 
            : base(url, Provider.filmworld, moviesProviderClient, movieDetailsProviderClient)
        {

        }
    }
}
