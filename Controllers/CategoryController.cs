using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GroGem.ViewModels;
using GroGem.Services;

namespace GroGem.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, CategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }
    [Route("Category")]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.ListAllCategories();

        return View(categories);
    }
    [Route("Category/{slug}-{categoryid}")]
    public async Task<IActionResult> ViewCategory(string slug, int categoryId)
    {
        var products = await _categoryService.ListCategoryProducts(categoryId);

        if(products is null){
            return NotFound();
        }
        
        return View(products);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
