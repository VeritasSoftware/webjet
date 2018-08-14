using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// FilmWorldProvider
    /// </summary>
    public class FilmWorldProvider : MovieProviderBase
    {
        public FilmWorldProvider(string url) : base(url, Provider.filmworld)
        {

        }
    }
}
