namespace Webjet.Entities
{
    public class ProviderMovie
    {
        Provider _movieProvider;
        Movie _movie;

        public Provider Name => _movieProvider;
        public Movie Movie => _movie;

        public ProviderMovie(Provider movieProvider, Movie movie)
        {
            _movieProvider = movieProvider;
            _movie = movie;
        }
    }
}
