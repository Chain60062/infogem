using Microsoft.AspNetCore.Mvc;
using InfoGem.Services;
using InfoGem.Dto;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, CategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategories();

        return Ok(categories);
    }

    [Route("{slug}")]
    [HttpGet]
    public async Task<IActionResult> GetCategory(string slug)
    {
        var category = await _categoryService.GetCategoryBySlug(slug);

        if (category is null) return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Createcategory([FromBody] CategoryDto categoryDto)
    {
        var category = await _categoryService.CreateNewCategory(categoryDto);

        if (category is null) return BadRequest();

        return CreatedAtAction("Getcategory", category.CategoryId, category);
    }

    [HttpPut]
    public async Task<IActionResult> Editcategory([FromBody] CategoryDto categoryDto, long categoryId)
    {
        try
        {
            var category = await _categoryService.EditCategory(categoryId, categoryDto);

            if (category is null) return NotFound();

            return Ok(category);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao editar produto.");
        }
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> Removecategory(long categoryId)
    {
        try
        {
            var category = await _categoryService.RemoveCategory(categoryId);

            if (category == false) return NotFound();

            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao remover produto.");
        }
    }
}
