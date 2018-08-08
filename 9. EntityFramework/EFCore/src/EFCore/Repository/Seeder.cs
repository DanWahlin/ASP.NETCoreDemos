using EFCore.Models;
using EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class Seeder
    {
        MoviesDbContext _context;

        public Seeder(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            var db = _context.Database;
            if (db != null)
            {
                // Create database and schema if it doesn't exist, then insert seed data
                if (await db.EnsureCreatedAsync())
                {
                    await InsertSampleData();
                }
            }
        }

        public async Task InsertSampleData()
        {
            await Task.Run(async () =>
            {
                var dist1 = _context.Distributors.Add(new Distributor { Name = "Light Saber Productions" });
                var dist2 = _context.Distributors.Add(new Distributor { Name = "Ewok Moon Productions" });

                _context.Movies.Add(new Movie { Title = "Star Wars", Director = "George Lucas",
                    Distributor = dist1.Entity });
                _context.Movies.Add(new Movie { Title = "Empire Strikes Back", Director = "Irvin Kershner",
                    Distributor = dist1.Entity });
                _context.Movies.Add(new Movie { Title = "Return of the Jedi", Director = "Richard Marquand",
                    Distributor = dist2.Entity });
                await _context.SaveChangesAsync();
            });
        }
    }
}

