using Ultra.Api.Data;
using Ultra.Api.DTOs;
using Ultra.Api.Models;
using Microsoft.EntityFrameworkCore;
namespace Ultra.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;
    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Product>> GetProductsAsync(ProductQueryDto query)
    {
        var products = _db.Products.Where(p => 
            p.Price >= query.MinPrice && p.Price <= query.MaxPrice);
        if (!string.IsNullOrWhiteSpace(query.Search)) 
            products = products.Where(p => EF.Functions.ILike(p.Name, $"%{query.Search}%"));
        return await products.OrderBy(p => p.Id).
            Skip((query.Page - 1) * query.PageSize).Take(query.PageSize).ToListAsync();
    }

    public async Task<Product?> FindAsync(int id)
    {
        return await _db.Products.FindAsync(id);
    }
    public async Task<Product?> FindFullAsync(int id)
    {
        return await _db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }
    
        public async Task AddProductAsync(Product product)
    {
        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
    }
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
    
    public async Task<bool> DeleteProductAsync(int id)
    {
        Product? product = await _db.Products.FindAsync(id);
        if (product == null) return false;
        _db.Products.Remove(product);
       await _db.SaveChangesAsync();
       return true; 
    }
}
