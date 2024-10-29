using InfoGem.Models;

namespace InfoGem.Repositories;

public interface ITagRepository
{
    public Task<Tag?> CreateNewTag(Tag tag);
    public IQueryable<Tag>? GetProductTags(long productId);
    public Task<Tag?> GetTagById(long cartId);

    public Task<bool> RemoveTagById(long cartId);

    public Task<Tag?> UpdateTag(long tagToBeUpdatedId, Tag tag);

    public Task<bool?> TagSlugExists(string slug);
}