using MovieStore.Models;
using System.ComponentModel.DataAnnotations;

namespace LabMvcApp.Models
{
    public class CreateMovieViewModel
    {
        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Bitte Titel eingeben")]
        public string Title { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Bitte Beschreibung eingeben")]
        public string Description { get; set; }

        public IFormFile? Image { get; set; }

        [Display(Name = "Preis")]
        [DataType(DataType.Currency)]
        [Range(0, 100, ErrorMessage = "Bitte mindestens 0 eingeben")]
        public decimal Price { get; set; }

        [Display(Name = "Bewertung")]
        [Range(0, 10, ErrorMessage = "Bitte Bewertung zwischen 0 und 10 eingeben")]
        public double IMDBRating { get; set; }

        [Required(ErrorMessage = "Bitte Genre auswaehlen")]
        public MovieGenre Genre { get; set; }

        [ClassicMovie(nameof(Genre))]
        [Display(Name = "Veröffentlichungsdatum")]
        public DateTime Published { get; set; } = new DateTime(2000, 1, 1);
    }
}
