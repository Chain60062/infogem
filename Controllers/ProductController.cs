using Microsoft.AspNetCore.Mvc;
using GroGem.ViewModels;
using GroGem.Services;
using Microsoft.AspNetCore.Authorization;
using GroGem.Helpers;

namespace GroGem.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    [Route("product/{slug}-{productId}")]
    public async Task<IActionResult> Index(string slug, int productId)
    {
        var product = await _productService.GetProductById(productId);

        if (product is null)
        {
            return NotFound();
        }
        
        ProductViewModel productViewModel = new()
        {
            Slug = product.Slug,
            Description = product.Description,
            ProductName = product.ProductName,
            Price = product.Price,
            Discount = product.Discount,
            AvailableUnits = product.AvailableUnits,
            Reviews = product.Reviews,
            Images = product.Images
        };

        return View(productViewModel);
    }
}