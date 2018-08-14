using System.Threading.Tasks;

namespace Webjet.Repository.Clients
{
    public interface IMovieProviderClient<TResponse>
        where TResponse : class
    {
        Task<TResponse> Get(string url);
    }
}
