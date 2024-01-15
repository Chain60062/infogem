using InfoGem.Models;

namespace InfoGem.Repositories;

public interface IImageRepository
{
    public Task<Image?> CreateImage(Image image);
    public Task<Image?> GetImageById(long imageId);
    public Task<Image?> UpdateImage(long imageTobeUpdatedId, Image image);
    public Task<bool> RemoveImageById(long imageId);
}