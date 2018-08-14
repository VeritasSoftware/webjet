using System.Collections.Generic;

namespace Webjet.Entities
{
    public class ProviderMovies
    {
        private Provider _movieProvider;

        public Provider Name => _movieProvider;
        public List<MovieBase> Movies { get; set; }

        public ProviderMovies(Provider movieProvider)
        {
            _movieProvider = movieProvider;
            this.Movies = new List<MovieBase>();
        }
    }
}
