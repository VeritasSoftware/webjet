using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    public class CinemaWorldProvider : MovieProviderBase
    {
        public CinemaWorldProvider(string url) : base(url, Provider.cinemaworld)
        {

        }
    }
}
