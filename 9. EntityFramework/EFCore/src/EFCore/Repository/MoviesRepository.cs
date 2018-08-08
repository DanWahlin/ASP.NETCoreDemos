using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        MoviesDbContext _context;

        public MoviesRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies
                .Include(movie => movie.Distributor)
                .ToListAsync();
        }

        public async Task<List<Distributor>> GetDistributors()
        {
            return await _context.Distributors
                .AsNoTracking() // Turns off change tracking - good for read-only scenarios where SaveChanges() isn't needed
                .ToListAsync();
        }

        // Example of a "raw query"
        public async Task<List<Movie>> GetRawMovies()
        {
            return await _context.Movies
                .FromSql("SELECT * FROM Movies")
                .ToListAsync();
        }
    }
}
