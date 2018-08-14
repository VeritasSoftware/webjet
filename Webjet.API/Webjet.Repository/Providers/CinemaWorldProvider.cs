using Webjet.Entities;

namespace Webjet.Repository.Providers
{
    /// <summary>
    /// Class CinemaWorldProvider
    /// </summary>
    public class CinemaWorldProvider : MovieProviderBase
    {
        public CinemaWorldProvider(string url) : base(url, Provider.cinemaworld)
        {

        }
    }
}
