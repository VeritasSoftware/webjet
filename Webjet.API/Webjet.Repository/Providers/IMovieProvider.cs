using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Interface IMovieProvider
    /// </summary>
    public interface IMovieProvider
    {
        Provider Name { get; }

        ProviderMovies GetMovies();
        ProviderMovie GetMovie(string id);
    }
}
