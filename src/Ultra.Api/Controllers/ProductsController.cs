using Microsoft.AspNetCore.Mvc;
using Ultra.Api.Services;
using Ultra.Api.DTOs;
using Ultra.Api.Models;
using System.ComponentModel.DataAnnotations;
namespace Ultra.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService; 
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductQueryDto productQuery)
    {
        return Ok(await _productService.GetProductsAsync(productQuery));
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetProductAsync(id);
        if (product != null) return Ok(product);
        return NotFound();
    }
    
    [HttpGet]
    [Route("{id}/category")]
    public async Task<IActionResult> GetProductWithCategory(int id)
    {
        GetProductDto? product = await _productService.GetProductWithCategoryAsync(id);
        if (product != null) return Ok(product);
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        int productId = await _productService.CreateProductAsync(productDto);
        return CreatedAtAction(
            nameof(GetProduct),
            new {id = productId},
            productId);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto productDto)
    {
        Product? product = await _productService.UpdateProductAsync(id, productDto);
        return (product != null) ? Ok(product) : NotFound();  
    }
    
    [HttpDelete]
    [Route ("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        return await _productService.DeleteProductAsync(id) ? NoContent() : NotFound(); 
    }
}
