using InfoGem.Dto;
using InfoGem.Models;
using InfoGem.Repositories;
using InfoGem.Utils;

namespace InfoGem.Services;

public class TagService
{
    private readonly ITagRepository _tagRepository;
    private static readonly Random random = new Random();

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public IQueryable<Tag>? GetProductTags(long productId)
        => _tagRepository.GetProductTags(productId);

    public async Task<Tag?> GetTag(long tagId) => await _tagRepository.GetTagById(tagId);

    public async Task<Tag?> CreateNewTag(TagDto tagDto)
    {
        var slug = tagDto.Title.ToSlug();//get slug
        slug = await ChangeIfSlugAlreadyExists(slug);

        var newTag = InstantiateTag(tagDto, slug);

        return await _tagRepository.CreateNewTag(newTag);
    }

    public async Task<Tag?> UpdateTagById(long tagToBeUpdatedId, TagDto tagDto)
    {
        var tag = InstantiateTag(tagDto);
        return await _tagRepository.UpdateTag(tagToBeUpdatedId, tag);
    }

    public async Task<bool?> RemoveTag(long tagId) => await _tagRepository.RemoveTagById(tagId);

    private async Task<string> ChangeIfSlugAlreadyExists(string slug)
    {
        var slugExists = await _tagRepository.TagSlugExists(slug);

        if (slugExists == false)
        {
            long randomNumber;
            lock (random)
            {
                randomNumber = random.Next(1, 10_000);
            }
            slug = $"{slug}-{randomNumber}";
        }

        return slug;
    }

    private Tag InstantiateTag(TagDto tagDto)
    {
        return new Tag()
        {
            Title = tagDto.Title,
            Description = tagDto.Description,
            Slug = tagDto.Slug
        };
    }
    private Tag InstantiateTag(TagDto tagDto, string slug)
    {
        return new Tag()
        {
            Title = tagDto.Title,
            Description = tagDto.Description,
            Slug = slug
        };
    }
}