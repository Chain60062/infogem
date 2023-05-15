using GroGem.Data;
using GroGem.Models;

namespace GroGem.Services;

public class ImageService
{
    private readonly ApplicationDbContext _db;
    private static readonly Random random = new Random();

    public ImageService(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Image> CreateImage(ImageViewModel image)
    {
        Image newImage = new(){
            Url = image.Url,
            AltText = image.AltText,
            Product = image.Product
        };

        await _db.Images.AddAsync(newImage);
        
        await _db.SaveChangesAsync();

        //this will return the freshly created object with id and other properties handled by the db like createAt, ef-core magic, don't ask me how they do this.
        return newImage;
    }

}