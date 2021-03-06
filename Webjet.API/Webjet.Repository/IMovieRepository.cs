﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Webjet.Entities;

namespace Webjet.Repository
{
    /// <summary>
    /// Interface IMovieRepository
    /// </summary>
    public interface IMovieRepository
    {
        Task<IEnumerable<ProviderMovie>> GetCheapestDeal(string title);
    }
}
