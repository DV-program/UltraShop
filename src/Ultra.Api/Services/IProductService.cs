using Ultra.Api.Models;
using Ultra.Api.DTOs;

namespace Ultra.Api.Services;

public interface IProductService
{
    public Task<List<Product>> GetProductsAsync(ProductQueryDto query);
    public Task<Product?> GetProductAsync(int id);
    public Task<GetProductDto?> GetProductWithCategoryAsync(int id);
    public Task<int> CreateProductAsync(CreateProductDto productDto);
    public Task<Product?> UpdateProductAsync(int id, UpdateProductDto productDto);
    public Task<bool> DeleteProductAsync(int id);
}
