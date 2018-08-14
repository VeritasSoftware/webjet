using System.Collections.Generic;
using System.Threading.Tasks;
using Webjet.Entities;

namespace Webjet.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<ProviderMovie>> GetCheapestDeal(string title);
    }
}
