using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.Models;

namespace EFCore.Repository
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetMovies();
    }
}