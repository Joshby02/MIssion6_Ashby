using Microsoft.EntityFrameworkCore;
using Mission6_Ashby.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Mission6_Ashby.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" }
            );

            modelBuilder.Entity<Director>().HasData(
                new Director { DirectorId = 1, DirectorName = "Christopher Nolan" },
                new Director { DirectorId = 2, DirectorName = "Frank Darabont" },
                new Director { DirectorId = 3, DirectorName = "Quentin Tarantino" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "The Dark Knight",
                    Year = "2008",
                    CategoryId = 1,
                    DirectorId = 1,
                    Rating = "PG-13",
                    Edited = false,
                    Notes = "Plex"
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "The Shawshank Redemption",
                    Year = "1994",
                    CategoryId = 3,
                    DirectorId = 2,
                    Rating = "R",
                    Edited = false,
                    Notes = "Blu-ray"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Pulp Fiction",
                    Year = "1994",
                    CategoryId = 3,
                    DirectorId = 3,
                    Rating = "R",
                    Edited = true,
                    Notes = "Plex"
                }
            );
        }
    }
}