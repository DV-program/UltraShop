namespace Ultra.Api.Services;

using Ultra.Api.Models;
using Ultra.Api.DTOs;
using Ultra.Api.Repositories;
using MapsterMapper;


public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<List<Product>> GetProductsAsync(ProductQueryDto query)
    {
        return await _repo.GetProductsAsync(query);
    }
    public async Task<Product?> GetProductAsync(int id)
    {
        return await _repo.FindAsync(id);
    }
    public async Task<GetProductDto?> GetProductWithCategoryAsync(int id)
    {
        Product? product = await _repo.FindFullAsync(id);
        if (product != null)
            return _mapper.Map<GetProductDto>(product);
        return null;
    }
    
    public async Task<int> CreateProductAsync(CreateProductDto productDto)
    {
        Product newProduct = MapToProduct(productDto);
        await _repo.AddProductAsync(newProduct);
        return newProduct.Id;
    }
    
    public async Task<Product?> UpdateProductAsync(int id,UpdateProductDto productDto)
    {
        Product? product = await _repo.FindAsync(id);
        if (product == null) return null; 
        product.Name = productDto.Name ?? product.Name;
        product.Price = productDto.Price.HasValue ? (decimal)productDto.Price : product.Price;
        product.CategoryId = productDto.CategoryId ?? product.CategoryId;
        await _repo.SaveAsync();
        return product;
    }
    
    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _repo.DeleteProductAsync(id);
    }
    
    public Product MapToProduct(CreateProductDto productDto)
    {
        return new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = productDto.CategoryId
        };
    }
    

}
