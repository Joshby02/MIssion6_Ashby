using Microsoft.EntityFrameworkCore;
using Mission6_Ashby.Models;

namespace Mission6_Ashby.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
