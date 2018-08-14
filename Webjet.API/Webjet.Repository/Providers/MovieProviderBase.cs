using System.Collections.Generic;
using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Abstract class MovieProviderBase
    /// </summary>
    public abstract class MovieProviderBase : IMovieProvider
    {
        private Provider _movieProvider;

        public MovieProviderBase(string url, Provider movieProvider)
        {
            _movieProvider = movieProvider;
        }

        public Provider Name => _movieProvider;

        /// <summary>
        /// Get movies for the provider
        /// </summary>
        /// <returns><see cref="ProviderMovies"/></returns>
        public virtual ProviderMovies GetMovies()
        {
            var providerMovies = new ProviderMovies(this.Name);

            providerMovies.Movies.AddRange(new List<Movie>()
            {
                new Movie { ID = "1", Title = "The return of the Jedi" }
            });

            return providerMovies;
        }

        /// <summary>
        /// Get movie details for the provider
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ProviderMovie GetMovie(string id)
        {
            if (this.Name == Provider.cinemaworld)
            {
                return new ProviderMovie(this.Name, new MovieDetails
                {
                    Title = "The return of the Jedi",
                    Price = "100",
                    ID = "1"
                });
            }
            else
            {
                return new ProviderMovie(this.Name, new MovieDetails
                {
                    Title = "The return of the Jedi",
                    Price = "150",
                    ID = "1"
                });
            }            
        }
    }
}
