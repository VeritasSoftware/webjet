namespace Webjet.Entities
{
    /// <summary>
    /// Class ProviderMovie
    /// </summary>
    public class ProviderMovie
    {
        Provider _movieProvider;
        MovieDetails _movie;

        public Provider Name => _movieProvider;
        public MovieDetails Movie => _movie;

        public ProviderMovie(Provider movieProvider, MovieDetails movie)
        {
            _movieProvider = movieProvider;
            _movie = movie;
        }
    }
}
