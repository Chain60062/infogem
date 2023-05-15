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
    public async Task<Product> GetProductBySlug(string slug)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Slug == slug);

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
            DiscountEndsAt = productViewModel.DiscountEndsAt
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
                var filePath = Path.Combine(_uploadsFolderPath, fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await image.CopyToAsync(stream);
                }
                newProduct.Images.Add(new Image { Url = filePath, AltText = "image", Product = newProduct });
            }
        }
        await _db.SaveChangesAsync();

        return newProduct;
    }
    // public async Task<bool> CreateProduct(ProductViewModel productViewModel)
    // {
    // var slug = productViewModel.Title.toSlug();
    // var slugAlreadyExists = await _db.Categories.FirstOrDefaultAsync(c => c.Slug == slug);

    // if (slugAlreadyExists is not null)
    // {
    //     int randomNumber;
    //     lock (random)
    //     {
    //         randomNumber = random.Next(1, 10_000);
    //     }
    //     slug = $"{slug}-{randomNumber}";
    // }
    // var newProduct = new Product
    // {
    //     Title = productViewModel.Title,
    //     Description = productViewModel.Description,
    //     Slug = slug
    // };

    // await _db.Categories.AddAsync(newCategory);

    // await _db.SaveChangesAsync();

    //     return true;
    // }
}