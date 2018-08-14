using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Webjet.Repository.Clients
{
    /// <summary>
    /// Class MovieProviderClient
    /// </summary>
    public class MovieProviderClient : IMovieProviderClient        
    {
        HttpClient _client;
        string _token;

        public MovieProviderClient(string token)
        {
            _client = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
            _token = token;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TResponse">The response type</typeparam>
        /// <param name="url">The url</param>
        /// <returns><see cref="Task{TResponse}"/></returns>
        public async Task<TResponse> Get<TResponse>(string url)
            where TResponse : class
        {
            _client.DefaultRequestHeaders.Add("x-access-token", _token);

            return await _client.GetAsync(url)
                                .ContinueWith(async x =>
                                {
                                    var result = x.Result;

                                    result.EnsureSuccessStatusCode();

                                    var response = await result.Content.ReadAsStringAsync();

                                    return JsonConvert.DeserializeObject<TResponse>(response);
                                }).Result;
        }
    }
}
