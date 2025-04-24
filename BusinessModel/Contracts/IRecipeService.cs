using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IRecipeService
    {
        void Add(Recipe recipe);
        Task AddWithImage(Recipe recipe, string fileName, Stream stream);
        bool Delete(long id);
        List<Recipe> GetAll();
        Recipe? GetById(long id);
        bool Update(Recipe recipe);
    }
}