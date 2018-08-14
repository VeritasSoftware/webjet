using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Webjet.Repository.Clients
{
    public class MovieProviderClient<TResponse> : IMovieProviderClient<TResponse>
        where TResponse : class
    {
        static HttpClient _client = new HttpClient();
        string _token;

        public MovieProviderClient(string token)
        {
            _token = token;
        }

        public async Task<TResponse> Get(string url)
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
