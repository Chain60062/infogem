using Microsoft.AspNetCore.Mvc;
using GroGem.ViewModels;
using GroGem.Services;
using Microsoft.AspNetCore.Authorization;
using GroGem.Models;
using System.Text.Json;

namespace GroGem.Areas.Admin;
[Authorize(Roles = "Administrators")]
[Area("Admin")]
public class HomeController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly ILogger<HomeController> _logger;
    // private readonly ImageService _imageService;
    private readonly ProductService _productService;


    public HomeController(ILogger<HomeController> logger, CategoryService categoryService, ProductService productService)
    {
        _logger = logger;
        _categoryService = categoryService;
        // _imageService = imageService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromForm] CategoryViewModel categoryViewModel)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.CreateCategory(categoryViewModel);

            return RedirectToAction(nameof(Index));
        }

        return View(categoryViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromForm] ProductViewModel productViewModel)
    {
        var newProduct = await _productService.CreateProduct(productViewModel);
        // Create the product and save it to the database
        // var productJson = JsonSerializer.Serialize(newProduct);

        // Console.WriteLine(productJson);

        return RedirectToAction("Index");
    }
}