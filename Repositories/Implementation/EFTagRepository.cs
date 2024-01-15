using InfoGem.Data;
using InfoGem.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Repositories;

public class EFTagRepository : ITagRepository
{
    private readonly AppDbContext _db;

    public EFTagRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Tag?> CreateNewTag(Tag tag)
    {
        await _db.Tags.AddAsync(tag);

        await _db.SaveChangesAsync();

        return tag;
    }

    public async Task<IQueryable<Tag>?> GetProductTags(long productId) => _db.Products.Where(p => p.ProductId == productId).SelectMany(p => p.Tags).AsQueryable();

    public async Task<Tag?> GetTagById(long tagId) => await _db.Tags.FindAsync(tagId);

    public async Task<bool> RemoveTagById(long tagId)
    {
        var tag = await _db.Tags.FindAsync(tagId);

        if (tag is null) return false;

        _db.Tags.Remove(tag);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Tag?> UpdateTag(long tagToBeUpdatedId, Tag tag)
    {
        var updatedTag = await _db.Tags.FindAsync(tagToBeUpdatedId);

        if (updatedTag is not null)
        {
            updatedTag.Slug = tag.Slug;
            updatedTag.Title = tag.Title;
            updatedTag.Description = tag.Description;

            _db.Update(updatedTag);
            await _db.SaveChangesAsync();
        }

        return updatedTag;
    }
    public async Task<bool?> TagSlugExists(string slug)
    {
        var slugExists = await _db.Categories.FirstOrDefaultAsync(c => c.Slug == slug);
        return slugExists is null ? false : true;
    }
}