using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IRecipeService
    {
        void Add(Recipe recipe);
        bool Delete(long id);
        List<Recipe> GetAll();
        Recipe? GetById(long id);
        bool Update(Recipe recipe);
    }
}