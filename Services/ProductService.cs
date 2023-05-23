using GroGem.Data;
using GroGem.Helpers;
using GroGem.Models;
using GroGem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GroGem.Services;

public class ProductService
{
    private readonly ApplicationDbContext _db;
    private readonly string[] _permittedExtensions = { ".png", ".jpeg", ".jpg", ".avif", ".svg", ".webp" };
    private readonly string _uploadsFolderPath = "wwwroot/uploads";
    private static readonly Random random = new Random();

    public ProductService()
    {
    }
    public ProductService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Product> GetProductById(int productId)
    {
        var product = await _db.Products.Include("Images").FirstOrDefaultAsync(p => p.ProductId == productId);

        return product!;
    }
    public async Task<Product> CreateProduct(ProductViewModel productViewModel)
    {
        var slug = productViewModel.ProductName.toSlug();
        var slugAlreadyExists = await _db.Products.FirstOrDefaultAsync(p => p.Slug == slug);

        if (slugAlreadyExists is not null)
        {
            int randomNumber;
            lock (random)
            {
                randomNumber = random.Next(1, 10_000);
            }
            slug = $"{slug}-{randomNumber}";
        }
        var productCategory = await _db.Categories.FindAsync(productViewModel.CategoryId);

        if (productCategory is null)
        {
            throw new ArgumentException("Desculpe, A categoria escolhida não foi encontrada.");
        }
        var newProduct = new Product()
        {
            ProductName = productViewModel.ProductName,
            Price = productViewModel.Price,
            Discount = productViewModel.Discount,
            Description = productViewModel.Description,
            AvailableUnits = productViewModel.AvailableUnits,
            Slug = slug,
            Reviews = productViewModel.Reviews,
            Images = productViewModel.Images,
            Sku = productViewModel.Sku,
            DiscountStartAt = productViewModel.DiscountStartAt,
            DiscountEndsAt = productViewModel.DiscountEndsAt,
            CategoryId = productViewModel.CategoryId
        };

        await _db.Products.AddAsync(newProduct);

        long size = productViewModel.FileUploadImages.Sum(i => i.Length);

        foreach (var image in productViewModel.FileUploadImages)
        {
            if (image.Length > 0)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                if (string.IsNullOrEmpty(fileExtension) || !_permittedExtensions.Contains(fileExtension))
                {
                    continue;
                }

                var fileName = $"{Guid.NewGuid().ToString()}{DateTime.UtcNow.ToString("yyyyMMddHHmmssfff")}{fileExtension}";
                var fullFilePath = Path.Combine(_uploadsFolderPath, fileName);
                var databaseFilePath = Path.Combine("uploads", fileName);

                using (var stream = System.IO.File.Create(fullFilePath))
                {
                    await image.CopyToAsync(stream);
                }
                newProduct.Images.Add(new Image { Url = databaseFilePath, AltText = "image", Product = newProduct });
            }
        }
        await _db.SaveChangesAsync();

        return newProduct;
    }
}