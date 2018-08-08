using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Repository
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() { }
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Distributor> Distributors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * SEEDING EXAMPLE (alternative to Repository/Seeder.cs)
             * modelBuilder.Entity<Movie>().HasData(new { Title = "Star Wars", Director = "George Lucas" });
             */

            /*
             * QUERY FILTER EXAMPLE
             * Example of a query filter (applies to all queries by default):
             * modelBuilder.Entity<Movie>().HasQueryFilter(m => !m.Title.Contains("Star"));
             * 
             * You can remove it for a given query by doing the following:
             * dbContext.Movies.IgnoreQueryFilters().ToListAsync();
             */
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Turn on support for lazy loading. Requires Microsoft.EntityFrameworkCore.Proxies package.
            // https://docs.microsoft.com/en-us/ef/core/querying/related-data#lazy-loading
            // If the the below option is used, then the call to Include() in MoviesRepository.cs isn't required
            // since it will "lazy load" the data. Keep in mind this would result in another call to the database.
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
