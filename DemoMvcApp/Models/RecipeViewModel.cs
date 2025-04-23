using BusinessLogic.Models.Enums;

namespace DemoMvcApp.Models
{
    public class RecipeViewModel
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public string[] Ingredients { get; set; } = [];
        public string[] Instructions { get; set; } = [];
        public int PrepTimeMinutes { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Servings { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Cuisine { get; set; }
        public int CaloriesPerServing { get; set; }
        public string[] Tags { get; set; } = [];
        public string? ImageUrl { get; set; }
        public float Rating { get; set; }
        public string? MealType { get; set; }
    }
}
