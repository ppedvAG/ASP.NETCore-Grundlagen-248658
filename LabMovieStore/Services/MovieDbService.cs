using MovieStore.Data;
using MovieStore.Contracts;
using MovieStore.Models;
using BusinessModel.Contracts;

namespace MovieStore.Services
{
    public class MovieDbService : IMovieService
    {
        private readonly MovieDbContext _context;
        private readonly IFileService _fileService;

        public MovieDbService(MovieDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public IList<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id); 
        }

        public async Task AddMovie(Movie movie, string filename = "", Stream? stream = null)
        {
            if (!string.IsNullOrWhiteSpace(filename) && stream != null)
            {
                movie.ImageUrl = await _fileService.UploadFile(filename, stream);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void RemoveMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
