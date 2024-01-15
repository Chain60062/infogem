using InfoGem.Data;
using InfoGem.Models;

namespace InfoGem.Repositories;
public class EFImageRepository : IImageRepository
{
    private readonly AppDbContext _db;

    public EFImageRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Image?> CreateImage(Image image)
    {
        await _db.Images.AddAsync(image);

        await _db.SaveChangesAsync();

        return image;
    }

    public async Task<Image?> GetImageById(long imageId)
        => await _db.Images.FindAsync(imageId);

    public async Task<bool> RemoveImageById(long imageId)
    {
        var image = await _db.Images.FindAsync(imageId);
        if (image is null) return false;

        _db.Images.Remove(image);

        var result = await _db.SaveChangesAsync();
        return result > 0 ? true : false;
    }

    public async Task<Image?> UpdateImage(long imageTobeUpdatedId, Image image)
    {
        var updatedImage = await _db.Images.FindAsync(imageTobeUpdatedId);

        if (updatedImage is not null)
        {
            updatedImage.Url = image.Url;
            updatedImage.AltText = image.AltText;
            updatedImage.IsMain = image.IsMain;

            _db.Update(updatedImage);
            await _db.SaveChangesAsync();
        }

        return updatedImage;
    }
}