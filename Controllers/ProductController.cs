using Microsoft.AspNetCore.Mvc;
using InfoGem.Services;
using Microsoft.EntityFrameworkCore;
using InfoGem.Dto;

namespace InfoGem.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController : Controller
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    [Route("{productId}")]
    [HttpGet]
    public async Task<IActionResult> GetProduct(long productId)
    {
        var product = await _productService.GetProductById(productId);

        if (product is null) return NotFound();

        return Ok(product);
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] int pageIndex, [FromQuery] int pageSize)
    {
        var products = await _productService.GetProducts(pageIndex, pageSize);

        return Ok(products);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
    {
        var product = await _productService.CreateProduct(productDto);

        if (product is null) return BadRequest();

        return CreatedAtAction("GetProduct", product.ProductId, product);
    }
    [HttpPut]
    public async Task<IActionResult> EditProduct([FromBody] ProductDto productDto, long productId)
    {
        try
        {
            var product = await _productService.EditProduct(productId, productDto);

            if (product is null) return NotFound();

            return Ok(product);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao editar produto.");
        }
    }
    [HttpDelete("{productId}")]
    public async Task<IActionResult> RemoveProduct(long productId)
    {
        try
        {
            var product = await _productService.RemoveProduct(productId);

            if (product == false) return NotFound();

            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao remover produto.");
        }
    }
}