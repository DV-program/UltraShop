using Microsoft.EntityFrameworkCore;
using Ultra.Api.Data;
using Ultra.Api.Models;

namespace Ultra.Api.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _db.Categories
            .OrderBy(c => c.Id)
            .ToListAsync();
    }

    public async Task<Category?> FindAsync(int id)
    {
        return await _db.Categories.FindAsync(id);
    }

    public async Task<Category?> FindFullAsync(int id)
    {
        return await _db.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _db.Categories.AddAsync(category);
        await _db.SaveChangesAsync();
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async Task MoveProductsToCategoryAsync(
        int fromCategoryId,
        int toCategoryId)
    {
        await _db.Products
            .Where(p => p.CategoryId == fromCategoryId)
            .ExecuteUpdateAsync(setters =>
                setters.SetProperty(p => p.CategoryId, toCategoryId));
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        Category? category = await _db.Categories.FindAsync(id);

        if (category == null)
            return false;

        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();

        return true;
    }
}