using System.Collections.Generic;
using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    public abstract class MovieProviderBase : IMovieProvider
    {
        private Provider _movieProvider;

        public MovieProviderBase(string url, Provider movieProvider)
        {
            _movieProvider = movieProvider;
        }

        public Provider Name => _movieProvider;

        public virtual ProviderMovies GetMovies()
        {
            var providerMovies = new ProviderMovies(this.Name);

            providerMovies.Movies.AddRange(new List<MovieBase>()
            {
                new MovieBase { ID = "1", Title = "The return of the Jedi" }
            });

            return providerMovies;
        }

        public virtual ProviderMovie GetMovie(string id)
        {
            return new ProviderMovie(this.Name, new Movie
            {
                Title = "The return of the Jedi",
                Price = "100",
                ID = "1"
            });
        }
    }
}
