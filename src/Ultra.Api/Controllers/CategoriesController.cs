using Microsoft.AspNetCore.Mvc;
using Ultra.Api.DTOs;
using Ultra.Api.Models;
using Ultra.Api.Services;

namespace Ultra.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await _categoryService.GetCategoriesAsync());
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        Category? category = await _categoryService.GetCategoryAsync(id);
        if (category != null) return Ok(category);
        return NotFound();
    }
    
    [HttpGet]
    [Route("{id}/products")]
    public async Task<IActionResult> GetCategoryWithProducts(int id)
    {
        GetCategoryDto? category = await _categoryService.GetCategoryWithProductsAsync(id);
        if (category != null) return Ok(category);
        return NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        int categoryId = await _categoryService.CreateCategoryAsync(categoryDto);
        return CreatedAtAction(
            nameof(GetCategory),
            new {id = categoryId},
            categoryId);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto categoryDto)
    {
        Category? category = await _categoryService.UpdateCategoryAsync(id, categoryDto);
        return (category != null) ? Ok(category) : NotFound();
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        return await _categoryService.DeleteCategoryAsync(id) ? NoContent() : NotFound();
    }
}
