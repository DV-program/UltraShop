using Microsoft.AspNetCore.Mvc;
using Ultra.Api.DTOs;
using Ultra.Api.Models;

namespace Ultra.Api.Repositories;

public interface IProductRepository
{
    public Task<List<Product>> GetProductsAsync(ProductQueryDto query);
    public Task AddProductAsync(Product product);
    public Task<bool> DeleteProductAsync(int id);
    public Task SaveAsync();
    public Task<Product?> FindAsync(int id);
    public Task<Product?> FindFullAsync(int id);
}
