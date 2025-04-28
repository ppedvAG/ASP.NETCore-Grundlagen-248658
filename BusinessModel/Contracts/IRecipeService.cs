using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IRecipeService
    {
        Task Add(Recipe recipe);
        Task AddWithImage(Recipe recipe, string fileName, Stream stream);
        Task<bool> Delete(long id);
        Task<PaginatedList<Recipe>> GetAll(int pageIndex = 1, int pageSize = 12);
        Task<Recipe?> GetById(long id);
        Task<bool> Update(Recipe recipe);
    }
}