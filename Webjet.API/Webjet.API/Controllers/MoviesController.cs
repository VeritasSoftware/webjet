using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webjet.Entities;
using Webjet.Repository;

namespace Webjet.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        readonly IMovieRepository _moviesRepository;

        public MoviesController(IMovieRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }        

        [HttpGet("cheapest/{title}")]
        public async Task<IEnumerable<ProviderMovie>> GetCheapestDeal(string title)
        {
            return await _moviesRepository.GetCheapestDeal(title);
        }        
    }
}
