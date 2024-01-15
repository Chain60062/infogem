using InfoGem.Dto;
using InfoGem.Utils;
using InfoGem.Models;
using InfoGem.Repositories;

namespace InfoGem.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private static readonly Random random = new Random();
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IQueryable<Category>?> GetAllCategories() => await _categoryRepository.GetAllCategories();

    public async Task<IQueryable<Product>?> GetCategoryProducts(long categoryId) => await _categoryRepository.GetCategoryProducts(categoryId);


    public async Task<Category> GetCategoryById(long categoryId)
    {
        var category = await _categoryRepository.GetCategoryById(categoryId);

        return category!;
    
    }
    public async Task<Category> GetCategoryBySlug(string slug)
    {
        var category = await _categoryRepository.GetCategoryBySlug(slug);

        return category!;
    }
    public async Task<Category?> CreateNewCategory(CategoryDto categoryDto)
    {
        var slug = categoryDto.Title.ToSlug();
        var slugExists = await _categoryRepository.CategorySlugExists(slug);
        if (slugExists is not null)
        {
            int randomNumber;
            lock (random)
            {
                randomNumber = random.Next(1, 10_000);
            }
            slug = $"{slug}-{randomNumber}";
        }
        var newCategory = new Category
        {
            Title = categoryDto.Title,
            Description = categoryDto.Description,
            Slug = slug
        };
        return await _categoryRepository.CreateNewCategory(newCategory);
    }
    public async Task<Category> EditCategory(long categoryToBeUpdatedId, CategoryDto newCategoryDto)
    {
        var newCategory = new Category
        {
            Title = newCategoryDto.Title,
            Slug = newCategoryDto.Slug,
            Description = newCategoryDto.Description
        };

        var updatedCategory = await _categoryRepository.UpdateCategoryById(categoryToBeUpdatedId, newCategory);
        return updatedCategory!;
    }

    public async Task<bool> RemoveCategory(long categoryId) =>
         await _categoryRepository.RemoveCategoryById(categoryId);
}