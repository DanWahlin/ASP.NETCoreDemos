using EFCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCRUD.Repository
{
    public interface IMoviesRepository : IDisposable
    {
        Task<int> CreateAsync(Movie movie);
        Task<int> DeleteAsync(int id);
        Task<int> EditAsync(Movie movie);
        Task<Movie> FindAsync(int id);
        Task<List<Movie>> ListAsync();
    }
}
