using System.Collections.Generic;
using Webjet.Entities;

namespace Webjet.Repository
{
    /// <summary>
    /// Class MovieEqualityComparer
    /// </summary>
    public class MovieEqualityComparer : IEqualityComparer<ProviderMovie>
    {
        public bool Equals(ProviderMovie x, ProviderMovie y)
        {
            return x.Name == y.Name && x.Movie.Title == y.Movie.Title;
        }

        public int GetHashCode(ProviderMovie obj)
        {
            return obj.Movie.Title.GetHashCode();
        }
    }
}
