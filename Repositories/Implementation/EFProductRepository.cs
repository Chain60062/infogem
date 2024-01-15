using InfoGem.Data;
using InfoGem.Exceptions;
using InfoGem.Models;
using InfoGem.Utils;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Repositories;

public class EFProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public EFProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Product?> CreateNewProduct(Product product)
    {
        await _db.AddAsync(product);

        await _db.SaveChangesAsync();

        return product;
    }

    public async Task<IQueryable<Product>?> GetAllProducts() => _db.Products.AsQueryable();

    //This will return a collection of the main image / thumbnail, it is a collection because of the srcset many resolutions
    public async Task<IQueryable<Image>?> GetProductMainImages(long productId)
    {
        var product = await _db.Products.FindAsync(productId);

        if (product is null) return null;

        var mainImageSet = product.Images.Where(i => i.IsMain == true).AsQueryable();

        return mainImageSet;
    }

    public async Task<IQueryable<Category>?> GetProductCategories(long productId)
    {
        var product = await _db.Products.FindAsync(productId);

        if (product is null) return null;

        var categories = product.Categories.AsQueryable();

        return categories;
    }

    public async Task<Product?> GetProductById(long productId) => await _db.Products.Include("Images").FirstOrDefaultAsync(p => p.ProductId == productId);
    public async Task<bool> RemoveProductById(long productId)
    {
        try
        {
            var product = await _db.Products.FindAsync(productId);

            if (product is null) return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return true;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }
    public async Task<IQueryable<Image>?> GetProductImages(long productId)
    {
        var product = await _db.Products.FindAsync(productId);
        if (product is null) return null;

        return product.Images.AsQueryable();
    }
    public async Task<Product?> UpdateProductById(long productToBeUpdatedId, Product product)
    {
        try
        {
            var updatedProduct = await _db.Products.FindAsync(productToBeUpdatedId);

            if (updatedProduct is not null)
            {
                updatedProduct.Slug = product.Slug;
                updatedProduct.AvailableUnits = product.AvailableUnits;
                updatedProduct.Price = product.Price;
                updatedProduct.ProductName = product.ProductName;
                updatedProduct.Sku = product.Sku;
                updatedProduct.Description = product.Description;
                _db.Update(updatedProduct);
                await _db.SaveChangesAsync();
            }

            return updatedProduct;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }
    public async Task<bool?> ProductSlugExists(string slug)
    {
        var slugExists = await _db.Products.FirstOrDefaultAsync(p => p.Slug == slug);
        return slugExists is null ? false : true;
    }
    public async Task<Product?> AddNewImageToProduct(string filePath, Product product)
    {
        product.Images.Add(new Image { Url = filePath, AltText = product.ProductName.ToSlug(), Product = product });

        await _db.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> AddImageToProduct(Image image, Product product)
    {
        product.Images.Add(image);

        await _db.SaveChangesAsync();

        return product;
    }
    public async Task<bool> RemoveImageFromProduct(Product product, Image image)
    {
        if (product.Images.Contains(image))
        {
            //image exists and is in the product image list
            product.Images.Remove(image);
            await _db.SaveChangesAsync();

            return true;
        }
        else return false;
    }
}