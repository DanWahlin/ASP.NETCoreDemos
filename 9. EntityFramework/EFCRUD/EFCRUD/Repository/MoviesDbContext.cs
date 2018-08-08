using EFCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCRUD.Repository
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add a shadow property
            modelBuilder.Entity<Movie>()
                .Property<DateTime>("LastUpdated");

            // Optional way to seed database
            // This app uses the seeder in Repository/MoviesDbContext.cs
            // modelBuilder.Entity<Movie>().HasData(new Movie { Title = "Star Wars", Director = "George Lucas" });

            // Example of using the Fluent API to map to a different table, and change a property
            //modelBuilder.Entity<Movie>()
            //.ToTable("tblMovies");

            //modelBuilder.Entity<Movie>()
            //    .Property(m => m.Title)
            //    .HasColumnName("MovieTitle")
            //    .HasMaxLength(100);

        }
    }
}
