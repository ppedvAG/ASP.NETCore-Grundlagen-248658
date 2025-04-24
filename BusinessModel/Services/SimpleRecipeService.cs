using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;

namespace BusinessModel.Services
{
    /// <summary>
    /// Service welcher den Datenbankzugriff simulieren soll, vgl. <see cref="https://de.wikipedia.org/wiki/Repository_(Entwurfsmuster)"/>.
    /// Dieser Service bildet CRUD Operationen auf die Recipes ab, <see cref="https://de.wikipedia.org/wiki/CRUD"/>.
    /// </summary>
    public class SimpleRecipeService : IRecipeService
    {
        private readonly List<Recipe> _recipes = RecipeReader.FromJsonFile() ?? new List<Recipe>();
        private readonly IFileService _fileService;

        public SimpleRecipeService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<Recipe> GetAll()
        {
            return _recipes;
        }

        public Recipe? GetById(long id)
        {
            return _recipes.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Recipe recipe)
        {
            _recipes.Insert(0, recipe);
        }

        public async Task AddWithImage(Recipe recipe, string fileName, Stream stream)
        {
            recipe.ImageUrl = await _fileService.UploadFile(fileName, stream);
            Add(recipe);
        }

        public bool Update(Recipe recipe)
        {
            var index = _recipes.FindIndex(r => r.Id == recipe.Id);
            if (index > 0)
            {
                _recipes[index] = recipe;
                return true;
            }
            return false;
        }

        public bool Delete(long id)
        {
            var index = _recipes.FindIndex(r => r.Id == id);
            if (index > 0)
            {
                _recipes.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
