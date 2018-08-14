using System.Threading.Tasks;

namespace Webjet.Repository.Clients
{
    public interface IMovieProviderClient        
    {
        Task<TResponse> Get<TResponse>(string url)
            where TResponse : class;
    }
}
