using System.Diagnostics;
using InfoGem.Dto;
using InfoGem.Exceptions;
using InfoGem.Models;
using InfoGem.Repositories;
namespace InfoGem.Services;

public class ImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IFileRepository _fileRepository;

    private static readonly Random random = new Random();

    public ImageService(IImageRepository imageRepository, IFileRepository fileRepository)
    {
        _imageRepository = imageRepository;
        _fileRepository = fileRepository;
    }
    public async Task<Image?> CreateImage(ImageDto imageDto)
    {
        var image = InstantiateImage(imageDto);

        if (imageDto.imageFile is not null)
        {
            var isImage = _fileRepository.IsFileAnImage(imageDto.imageFile);
            if (!isImage) throw new FileIsNotAnImageException("Arquivo não é uma imagem.");

            await _fileRepository.UploadFile(imageDto.imageFile);
            return await _imageRepository.CreateImage(image);
        }
        return null;
    }
    public async Task<bool> RemoveImage(long imageId)
    {
        var image = await _imageRepository.GetImageById(imageId);
        if (image is null) return false;

        _fileRepository.RemoveFile(image.Url);
        return await _imageRepository.RemoveImageById(imageId);
    }

    public async Task<Image?> UpdateImage(long imageToBeUpdatedId, ImageDto imageDto)
    {
        var image = InstantiateImage(imageDto);

        return await _imageRepository.UpdateImage(imageToBeUpdatedId, image);
    }
    private Image InstantiateImage(ImageDto imageDto)
    {
        return new Image()
        {
            Url = imageDto.Url,
            AltText = imageDto.AltText,
        };
    }
}