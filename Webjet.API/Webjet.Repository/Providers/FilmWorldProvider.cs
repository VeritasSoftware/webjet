using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    public class FilmWorldProvider : MovieProviderBase
    {
        public FilmWorldProvider(string url) : base(url, Provider.filmworld)
        {

        }
    }
}
