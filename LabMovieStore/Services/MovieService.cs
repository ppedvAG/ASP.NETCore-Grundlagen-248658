using MovieStore.Contracts;
using MovieStore.Models;

namespace MovieStore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IList<Movie> _movies =
        [
            new Movie
            {
                Id = 1,
                Title = "Die Verurteilten (The Shawshank Redemption)",
                Description = "Erzählt die Geschichte von Andy Dufresne, einem Banker, der fälschlicherweise wegen Mordes an seiner Frau und deren Liebhaber verurteilt wird und im Gefängnis Freundschaft mit einem Mitgefangenen namens Red schließt, während er über Jahrzehnte hinweg an einem Fluchtplan arbeitet.",
                Genre = MovieGenre.Drama,
                Price = 13.99m,
                PublishedDate = new DateTime(1994, 10, 14),
                IMDBRating = 8.5,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg"
            },
            new Movie
            {
                Id = 2,
                Title = "Der Pate (The Godfather)",
                Description = "Erzählt die Geschichte der Corleone-Familie, die von einem Mafia-Patriarchen geführt wird, und die Machtkämpfe und familiären Konflikte, die entstehen, als sein Sohn die Kontrolle übernimmt.",
                Genre = MovieGenre.Drama,
                Price = 19.99m,
                PublishedDate = new DateTime(1972, 3, 24),
                IMDBRating = 7.6,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg"
            },
            new Movie
            {
                Id = 3,
                Title = "Jurassic Park",
                Description = "Handelt von einem Themenpark mit geklonten Dinosauriern, der von Wissenschaftlern und Besuchern erkundet wird, bis ein Sabotageakt die Sicherheitssysteme außer Kraft setzt und die Dinosaurier freilässt, was zu einer gefährlichen Flucht ums Überleben führt.",
                Genre = MovieGenre.Adventure,
                Price = 12.99m,
                PublishedDate = new DateTime(1993, 11, 8),
                IMDBRating = 9,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e7/Jurassic_Park_poster.jpg"
            }
        ];

        public IList<Movie> GetMovies()
        {
            return _movies;
        }

        public Movie? GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            movie.Id = _movies.Max(m => m.Id) + 1;
            _movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movies.Remove(movie);
            _movies.Add(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            _movies.Remove(movie);
        }
    }
}
