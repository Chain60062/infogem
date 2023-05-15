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
    public async Task<IActionResult> ViewCategories()
    {
        var categories = await _categoryService.ListAllCategories();
        var categoriesViewModel = new List<CategoryViewModel>();

        foreach (var c in categories)
        {
            CategoryViewModel model = new();
            model.Title = c.Title;
            model.Description = c.Description!;
            categoriesViewModel.Add(model);
        }
        return View(categoriesViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
