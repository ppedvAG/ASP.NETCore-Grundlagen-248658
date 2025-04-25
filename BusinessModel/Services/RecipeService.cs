using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services
{
    /// <summary>
    /// Dieser Service bildet CRUD Operationen auf die Recipes ab, <see cref="https://de.wikipedia.org/wiki/CRUD"/>.
    /// </summary>
    public class RecipeService : IRecipeService
    {
        private readonly DeliveryDbContext _context;
        private readonly IFileService _fileService;

        public RecipeService(DeliveryDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public Task<List<Recipe>> GetAll()
        {
            return _context.Recipes.ToListAsync();
        }

        public async Task<Recipe?> GetById(long id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task Add(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task AddWithImage(Recipe recipe, string fileName, Stream stream)
        {
            recipe.ImageUrl = await _fileService.UploadFile(fileName, stream);
            await Add(recipe);
        }

        public async Task<bool> Update(Recipe recipe)
        {
            var existing = await GetById(recipe.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(long id)
        {
            var existing = await GetById(id);
            if (existing != null)
            {
                _context.Recipes.Remove(existing);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
