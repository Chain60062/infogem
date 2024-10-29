using InfoGem.Models;

namespace InfoGem.Repositories;

public interface IProductRepository
{
    public Task<Product?> CreateNewProduct(Product product);

    public IQueryable<Product>? GetAllProducts();
    public Task<PaginatedList<Product>?> GetProducts(int pageIndex, int pageSize);

    public Task<IQueryable<Image>?> GetProductImages(long productId);

    public Task<IQueryable<Category>?> GetProductCategories(long productId);

    public Task<Product?> GetProductById(long productId);

    public Task<Product?> UpdateProductById(long productToBeUpdatedId, Product product);
    public Task<bool> RemoveProductById(long productId);

    public Task<bool?> ProductSlugExists(string slug);
    public Task<Product?> AddNewImageToProduct(string filePath, Product product);
    public Task<bool> RemoveImageFromProduct(Product product, Image image);
}