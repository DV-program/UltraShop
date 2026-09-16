using Ultra.Api.DTOs;
using Ultra.Api.Models;
using Ultra.Api.Repositories;

namespace Ultra.Api.Services;

public class CategoryService : ICategoryService
{
    private const int NoCategoryId = 1;

    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _repo.GetCategoriesAsync();
    }

    public async Task<Category?> GetCategoryAsync(int id)
    {
        return await _repo.FindAsync(id);
    }

    public async Task<GetCategoryDto?> GetCategoryWithProductsAsync(int id)
    {
        Category? category = await _repo.FindFullAsync(id);

        if (category == null)
            return null;

        return new GetCategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Products = category.Products.Select(p => new GetCategoryProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList()
        };
    }

    public async Task<int> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        Category newCategory = MapToCategory(categoryDto);

        await _repo.AddCategoryAsync(newCategory);

        return newCategory.Id;
    }

    public async Task<Category?> UpdateCategoryAsync(
        int id,
        UpdateCategoryDto categoryDto)
    {
        Category? category = await _repo.FindAsync(id);

        if (category == null)
            return null;

        category.Name = categoryDto.Name ?? category.Name;

        await _repo.SaveAsync();

        return category;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        if (id == NoCategoryId)
            return false;

        Category? category = await _repo.FindAsync(id);

        if (category == null)
            return false;

        await _repo.MoveProductsToCategoryAsync(id, NoCategoryId);
        return await _repo.DeleteCategoryAsync(id);
    }

    private Category MapToCategory(CreateCategoryDto categoryDto)
    {
        return new Category
        {
            Name = categoryDto.Name
        };
    }
}