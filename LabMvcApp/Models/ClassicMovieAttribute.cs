using MovieStore.Models;
using System.ComponentModel.DataAnnotations;

namespace LabMvcApp.Models
{
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public ClassicMovieAttribute(int year) => Year = year;

        public int Year { get; }
        public string GetErrorMessage() =>
            $"Classic novies must have a release year no later than {Year}.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var genre = ((CreateMovieViewModel)validationContext.ObjectInstance).Genre;
            if (genre == MovieGenre.Classic 
                && value is DateTime dt 
                && dt.Year > Year)
            {
                return new ValidationResult(GetErrorMessage());

            }
            return ValidationResult.Success;
        }
    }
}