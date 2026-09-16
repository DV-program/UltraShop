using Ultra.Api.DTOs;
using Ultra.Api.Models;

namespace Ultra.Api.Services;

public interface ICategoryService
{
    public Task<List<Category>> GetCategoriesAsync();
    public Task<Category?> GetCategoryAsync(int id);
    public Task<GetCategoryDto?> GetCategoryWithProductsAsync(int id);
    public Task<int> CreateCategoryAsync(CreateCategoryDto categoryDto);
    public Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryDto categoryDto);
    public Task<bool> DeleteCategoryAsync(int id);
}
