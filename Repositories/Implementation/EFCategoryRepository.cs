using InfoGem.Data;
using InfoGem.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Repositories;

public class EFCategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _db;

    public EFCategoryRepository(AppDbContext db)
    {
        _db = db;
    }
    public async Task<IQueryable<Product>?> GetCategoryProducts(long categoryId)
    {
        var category = await _db.Categories.FindAsync(categoryId);

        return category?.Products.AsQueryable();
    }
    public IQueryable<Category>? GetAllCategories() => _db.Categories.AsQueryable();
    public async Task<Category?> GetCategoryById(long categoryId) => await _db.Categories.FindAsync(categoryId);
    public async Task<Category?> GetCategoryBySlug(string slug) => await _db.Categories.FirstOrDefaultAsync(c => c.Slug == slug);

    public async Task<bool?> CategorySlugExists(string slug)
    {
        var slugExists = await GetCategoryBySlug(slug);
        return slugExists is null ? false : true;
    }

    public async Task<bool> RemoveCategoryById(long categoryId)
    {
        var category = await _db.Categories.FindAsync(categoryId);

        if (category is null) return false;

        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Category?> UpdateCategoryById(long categoryToBeUpdatedId, Category category)
    {
        var updatedCategory = await _db.Categories.FindAsync(categoryToBeUpdatedId);

        if (updatedCategory is not null)
        {
            updatedCategory.Description = category.Description;
            updatedCategory.Slug = category.Slug;
            updatedCategory.Title = category.Title;

            _db.Update(updatedCategory);
            await _db.SaveChangesAsync();
        }

        return updatedCategory;
    }

    public async Task<Category?> CreateNewCategory(Category category)
    {
        await _db.Categories.AddAsync(category);
        await _db.SaveChangesAsync();
        return category;
    }
}