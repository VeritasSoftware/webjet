using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webjet.Entities;
using Webjet.Repository.Providers;

namespace Webjet.Repository
{
    /// <summary>
    /// Class MovieRepository
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        IEnumerable<IMovieProvider> _movieProviders;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="movieProviders">The injected movie providers</param>
        public MovieRepository(List<IMovieProvider> movieProviders)
        {
            _movieProviders = movieProviders;
        }

        /// <summary>
        /// Get cheapest deal for a movie from all providers
        /// </summary>
        /// <param name="title">The title words of the movie</param>
        /// <returns><see cref="Task{IEnumerable{ProviderMovie}}"/></returns>
        public async Task<IEnumerable<ProviderMovie>> GetCheapestDeal(string title)
        {
            return await Task.Run(() =>
            {
                var moviesFromAllProviders = new ConcurrentBag<ProviderMovies>();

                //Get all movies
                Parallel.ForEach(_movieProviders, provider =>
                {                    
                    var movies = provider.GetMovies();

                    moviesFromAllProviders.Add(movies);
                });

                //Get movies that match the title
                var foundMoviesFromProviders = moviesFromAllProviders.Select(providerMovies => {
                    var p = new ProviderMovies(providerMovies.Name);

                    p.Movies.AddRange(providerMovies.Movies.Where(m => m.Title.Contains(title)));

                    return p;
                });

                var movieDetailsFromProviders = new ConcurrentBag<ProviderMovie>();

                //Get all movie details for found movies
                Parallel.ForEach(foundMoviesFromProviders, providerMovies =>
                {
                    Parallel.ForEach(providerMovies.Movies, movie =>
                    {
                        var m = _movieProviders.Single(x => x.Name == providerMovies.Name).GetMovie(movie.ID);
                        movieDetailsFromProviders.Add(m);
                    });
                });

                var distictMovies = movieDetailsFromProviders.Distinct(new MovieEqualityComparer());

                var leastPriceMovies = distictMovies.Where(m => decimal.Parse(m.Movie.Price) <= distictMovies.Where(x => x.Name != m.Name).Min(y => decimal.Parse(y.Movie.Price)));

                return leastPriceMovies;
            });
        }        
    }
}
