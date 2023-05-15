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
    [Route("product/{slug}")]
    public async Task<IActionResult> Product(string slug)
    {
        var product = await _productService.GetProductBySlug(slug);

        if (product is null)
        {
            return NotFound();
        }

        ProductViewModel productModel = new()
        {
            Slug = product.Slug,
            Description = product.Description,
            ProductName = product.ProductName,
            Price = product.Price,
            Discount = product.Discount,
            AvailableUnits = product.AvailableUnits,
            Reviews = product.Reviews,
        };

        return View(product);
    }

    [Route("product/create")]
    public async Task<IActionResult> CreateProduct([FromForm] ProductViewModel product)
    {
        ProductViewModel productViewModel = new()
        {
            ProductName = product.ProductName,
            Description = product.Description,
            AvailableUnits = product.AvailableUnits,
            Discount = product.Discount,
            Price = product.Price,
            FileUploadImages = product.FileUploadImages,
            Slug = product.ProductName.toSlug(),
        };
        var isCreateSuccess = await _productService.CreateProduct(product);

        return View(isCreateSuccess);
    }
}