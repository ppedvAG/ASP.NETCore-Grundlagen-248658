using BusinessModel.Models;
using DemoMvcApp.Models;

namespace DemoMvcApp.Mappers
{
    public static class RecipesMapper
    {
        /// <summary>
        /// Eine sog. Extension Methode, welche die Funktionalitaet von <see cref="Recipe"/> erweitert.
        /// Wir wollen keine Logik in dem Domain Model und auch nicht in der Business Logic haben, 
        /// weswegen wir das Mapping in dieser Assembly nur an dieser Stelle erweitern.
        /// 
        /// Alternative: AutoMapper, aber nicht empfohlen.
        /// Vorteil von diesem explizitem Mapping: Wir haben jederzeit die volle Kontrolle ueber das Mapping,
        /// auch wenn es sehr repetativ erscheint.
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns></returns>
        public static RecipeViewModel ToViewModel(this Recipe domainModel)
        {
            return new RecipeViewModel
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Ingredients = domainModel.Ingredients,
                Instructions = domainModel.Instructions,
                ImageUrl = domainModel.ImageUrl,
                CaloriesPerServing = domainModel.CaloriesPerServing,
                MealType = domainModel.MealType.FirstOrDefault(),
                PrepTimeMinutes = domainModel.PrepTimeMinutes,
                CookTimeMinutes = domainModel.CookTimeMinutes,
                Cuisine = domainModel.Cuisine,
                Difficulty = domainModel.Difficulty,
                Rating = domainModel.Rating,
                Servings = domainModel.Servings,
                Tags = domainModel.Tags,
            };
        }
    }
}
