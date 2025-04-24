using BusinessLogic.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DemoMvcApp.Models
{
    public class CreateRecipeViewModel
    {
        [Required(ErrorMessage = "Name für das Rezept ist erforderlich!")]
        [MinLength(4, ErrorMessage = "Name muss mindestens 4 Zeichen lang sein!")]
        [MaxLength(100, ErrorMessage = "Name darf maximal 100 Zeichen lang sein!")]
        public string Name { get; set; }

        public IFormFile? Image { get; set; }

        [Display(Name = "Zutaten")]
        public string? Ingredients { get; set; }

        [Display(Name = "Zubereitung")]
        public string? Instructions { get; set; }

        [Display(Name = "Verarbeitungszeit (in Minuten)")]
        [Range(0, 120, ErrorMessage = "Preparation Time must be between 0 and 120 minutes!")]
        public int PrepTimeMinutes { get; set; }

        [Display(Name = "Kochzeit (in Minuten)")]
        [Range(0, 120, ErrorMessage = "Preparation Time must be between 0 and 120 minutes!")]
        public int CookTimeMinutes { get; set; }

        [Display(Name = "Portionen")]
        public int Servings { get; set; }

        [Display(Name = "Kalorien pro Portion")]
        public int CaloriesPerServing { get; set; }

        [Display(Name = "Mahlzeit")]
        public MealType MealType { get; set; }

        [Display(Name = "Schwierigkeit")]
        public Difficulty Difficulty { get; set; }

        [Display(Name = "Küche")]
        public Cuisine Cuisine { get; set; }

        public string? Tags { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5!")]
        public float Rating { get; set; }
    }
}
