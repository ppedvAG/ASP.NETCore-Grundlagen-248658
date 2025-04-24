using MovieStore.Models;

namespace MovieStore.Contracts
{
    public interface IMovieService
    {
        Task AddMovie(Movie movie, string filename = "", Stream? stream = null);
        Movie? GetById(int id);
        IList<Movie> GetMovies();
        void RemoveMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}