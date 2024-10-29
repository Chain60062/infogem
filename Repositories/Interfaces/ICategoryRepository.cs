using InfoGem.Models;

namespace InfoGem.Repositories;

public interface ICategoryRepository
{
    public Task<Category?> GetCategoryById(long categoryId);
    public Task<Category?> GetCategoryBySlug(string slug);
    public Task<IQueryable<Product>?> GetCategoryProducts(long categoryId);
    public IQueryable<Category>? GetAllCategories();
    public Task<Category?> CreateNewCategory(Category category);
    public Task<Category?> UpdateCategoryById(long categoryToBeUpdatedId, Category category);
    public Task<bool> RemoveCategoryById(long categoryId);
    public Task<bool?> CategorySlugExists(string slug);
}