using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
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
        private IMovieProviderClient _moviesProviderClient;
        private ICacheProvider _cacheProvider;

        public MovieProviderBase(string url, Provider movieProvider, 
                                    IMovieProviderClient moviesProviderClient,
                                    ICacheProvider cacheProvider)
        {
            _url = url;
            _movieProvider = movieProvider;
            _moviesProviderClient = moviesProviderClient;
            _cacheProvider = cacheProvider;
        }

        public Provider Name => _movieProvider;

        /// <summary>
        /// Get movies for the provider
        /// </summary>
        /// <returns><see cref="ProviderMovies"/></returns>
        public virtual ProviderMovies GetMovies()
        {
            var providerMovies = new ProviderMovies(_movieProvider);

            return _cacheProvider.GetCacheEntry($"{this.Name + "Movies"}", () =>
            {
                var movies = _moviesProviderClient.Get<MoviesCollection>(_url + "movies").Result;

                movies.Movies.OrderBy(movie => movie.Title).ToList()
                             .ForEach(movie => providerMovies.Movies.Add(movie));

                return providerMovies;
            });
           
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
            return _cacheProvider.GetCacheEntry($"{this.Name}_Movie_{id}", () =>
                                                                            new ProviderMovie(
                                                                                                _movieProvider, 
                                                                                                _moviesProviderClient.Get<MovieDetails>(_url + $"movie/{id}").Result
                                                                                             )
                                                );


            //return new ProviderMovie(_movieProvider, _moviesProviderClient.Get<MovieDetails>(_url + $"movie/{id}").Result);

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
