using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    public interface IMovieProvider
    {
        Provider Name { get; }

        ProviderMovies GetMovies();
        ProviderMovie GetMovie(string id);
    }
}
