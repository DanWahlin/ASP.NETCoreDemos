using EFCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCRUD.Repository
{
    public class MoviesRepository : IMoviesRepository
    {

        MoviesDbContext _dbContext;

        public MoviesRepository(MoviesDbContext db)
        {
            _dbContext = db;
        }

        public async Task<Movie> FindAsync(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }


        public async Task<List<Movie>> ListAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }


        public async Task<int> CreateAsync(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<int> EditAsync(Movie movie)
        {
            // Could do this if we want to update everything in the movie object
            //_dbContext.Movies.Attach(movie);
            //_dbContext.Entry(movie).State = EntityState.Modified;
            //_dbContext.SaveChanges();

            // This technique works well when you want to selectively
            // update some model object properties (but not all of them)
            var originalMovie = await FindAsync(movie.Id);
            originalMovie.Title = movie.Title;
            originalMovie.Director = movie.Director;
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<int> DeleteAsync(int id)
        {
            var movie = await FindAsync(id);
            _dbContext.Movies.Remove(movie);
            return await _dbContext.SaveChangesAsync();
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
