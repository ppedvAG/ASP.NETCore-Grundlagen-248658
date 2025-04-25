using Microsoft.EntityFrameworkCore;
using MovieStore.Models;
using MovieStore.Services;

namespace MovieStore.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var movies = new InMemoryMovieService(null).GetMovies();
            modelBuilder.Entity<Movie>().HasData(movies);
        }
    }
}
