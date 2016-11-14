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
                if (await db.EnsureCreatedAsync())
                {
                    await InsertSampleData();
                }
            }
            else
            {
                await InsertSampleData();
            }
        }

        public async Task InsertSampleData()
        {
            await Task.Run(async () =>
            {
                _context.Movies.Add(new Movie { Title = "Star Wars", Director = "George Lucas" });
                _context.Movies.Add(new Movie { Title = "Empire Strikes Back", Director = "George Lucas" });
                await _context.SaveChangesAsync();
            });
        }
    }
}

