using GroGem.Data;
using GroGem.Helpers;
using GroGem.Models;
using GroGem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GroGem.Services;

public class CategoryService
{
    private readonly ApplicationDbContext _db;
    private static readonly Random random = new Random();

    public CategoryService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Category>> ListAllCategories()
    {
        List<Category> categories = await _db.Categories.ToListAsync();

        return categories!;
    }
    
    public async Task<bool> CreateCategory(CategoryViewModel categoryViewModel)
    {
        var slug = categoryViewModel.Title.toSlug();
        var slugAlreadyExists = await _db.Categories.FirstOrDefaultAsync(c => c.Slug == slug);

        if(slugAlreadyExists is not null){
            int randomNumber;
            lock(random){
                randomNumber = random.Next(1, 10_000);
            }
            slug = $"{slug}-{randomNumber}";
        }
        var newCategory = new Category
        {
            Title = categoryViewModel.Title,
            Description = categoryViewModel.Description,
            Products = categoryViewModel.Products,
            Slug = slug
        };

        await _db.Categories.AddAsync(newCategory);

        await _db.SaveChangesAsync();

        return true;
    }
public async Task<Category> EditCategory(int categoryId, Category updatedCategory)
    {
        var existingCategory = await _db.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

        if (existingCategory is not null)
        {
            existingCategory.Title = updatedCategory.Title;
            existingCategory.Description = updatedCategory.Description;

            await _db.SaveChangesAsync();
        }

        return existingCategory!;
    }

    public async Task<bool> DeleteCategory(int categoryId)
    {
        var categoryToDelete = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == categoryId);

        if (categoryToDelete is not null)
        {
            _db.Products.Remove(categoryToDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        return false;
    }

}