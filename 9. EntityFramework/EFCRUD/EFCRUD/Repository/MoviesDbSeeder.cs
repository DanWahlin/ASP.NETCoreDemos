using EFCRUD.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCRUD.Repository
{
    public class MoviesDbSeeder
    {
        readonly ILogger _Logger;

        public MoviesDbSeeder(ILoggerFactory loggerFactory)
        {
            _Logger = loggerFactory.CreateLogger("CustomersDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var moviesDb = serviceScope.ServiceProvider.GetService<MoviesDbContext>();
                if (await moviesDb.Database.EnsureCreatedAsync())
                {
                    if (!await moviesDb.Movies.AnyAsync())
                    {
                        await InsertMoviesSampleData(moviesDb);
                    }
                }
            }
        }

        public async Task InsertMoviesSampleData(MoviesDbContext db)
        {
            var movies = GetMovies();
            db.Movies.AddRange(movies);

            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} customers");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(MoviesDbSeeder)}: " + exp.Message);
                throw;
            }

        }

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Star Wars", Director = "George Lucas" },
                new Movie { Title = "Empire Strikes Back", Director = "Irvin Kershner" },
                new Movie { Title = "Return of the Jedi", Director = "Richard Marquand" }
            };

            return movies;

        }

    }
}
