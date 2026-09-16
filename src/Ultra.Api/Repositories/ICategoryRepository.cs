using Ultra.Api.Models;

namespace Ultra.Api.Repositories;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task AddCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
    Task SaveAsync();
    Task<Category?> FindAsync(int id);
    Task<Category?> FindFullAsync(int id);
    Task MoveProductsToCategoryAsync(int fromCategoryId, int toCategoryId);
}