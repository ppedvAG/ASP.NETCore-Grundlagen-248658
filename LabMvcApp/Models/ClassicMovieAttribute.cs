using MovieStore.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LabMvcApp.Models
{
    public class ClassicMovieAttribute(string genreKey, int year = 1950) 
        : ValidationAttribute($"Klassiker müssen vor {year} erschienen sein.")
    {
        private readonly string _genreKey = genreKey;

        public int Year { get; } = year;

        protected override ValidationResult? IsValid(object? value, 
            ValidationContext context)
        {
            var genreProp = context.ObjectType.GetRuntimeProperty(_genreKey);
            var genre = genreProp.GetValue(context.ObjectInstance);
            if (genre.Equals(MovieGenre.Classic)
                && value is DateTime dt 
                && dt.Year > Year)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}