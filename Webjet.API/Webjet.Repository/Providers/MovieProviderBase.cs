using System.Linq;
using Webjet.Entities;
using Webjet.Repository.Clients;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Abstract class MovieProviderBase
    /// </summary>
    public abstract class MovieProviderBase : IMovieProvider
    {
        private string _url;
        private Provider _movieProvider;
        private IMovieProviderClient<MoviesCollection> _moviesProviderClient;
        private IMovieProviderClient<MovieDetails> _movieDetailsProviderClient;

        public MovieProviderBase(string url, Provider movieProvider, 
                                    IMovieProviderClient<MoviesCollection> moviesProviderClient,
                                    IMovieProviderClient<MovieDetails> movieDetailsProviderClient)
        {
            _url = url;
            _movieProvider = movieProvider;
            _moviesProviderClient = moviesProviderClient;
            _movieDetailsProviderClient = movieDetailsProviderClient;
        }

        public Provider Name => _movieProvider;

        /// <summary>
        /// Get movies for the provider
        /// </summary>
        /// <returns><see cref="ProviderMovies"/></returns>
        public virtual ProviderMovies GetMovies()
        {
            var providerMovies = new ProviderMovies(_movieProvider);

            var movies = _moviesProviderClient.Get(_url + "movies").Result;

            movies.Movies.ToList().ForEach(movie => providerMovies.Movies.Add(movie));

            return providerMovies;

            //var providerMovies = new ProviderMovies(this.Name);

            //providerMovies.Movies.AddRange(new List<Movie>()
            //{
            //    new Movie { ID = "1", Title = "The return of the Jedi" }
            //});

            //return providerMovies;
        }

        /// <summary>
        /// Get movie details for the provider
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ProviderMovie GetMovie(string id)
        {
            return new ProviderMovie(_movieProvider, _movieDetailsProviderClient.Get(_url + $"movie/{id}").Result);

            //if (this.Name == Provider.cinemaworld)
            //{
            //    return new ProviderMovie(this.Name, new MovieDetails
            //    {
            //        Title = "The return of the Jedi",
            //        Price = "100",
            //        ID = "1"
            //    });
            //}
            //else
            //{
            //    return new ProviderMovie(this.Name, new MovieDetails
            //    {
            //        Title = "The return of the Jedi",
            //        Price = "150",
            //        ID = "1"
            //    });
            //}            
        }
    }
}
