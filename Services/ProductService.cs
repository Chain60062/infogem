using InfoGem.Utils;
using InfoGem.Models;
using InfoGem.Repositories;
using InfoGem.Exceptions;
using InfoGem.Dto;

namespace InfoGem.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IFileRepository _fileRepository;
    private static readonly Random random = new Random();

    public ProductService(IProductRepository productRepository, IImageRepository imageRepository, IFileRepository fileRepository)
    {
        _productRepository = productRepository;
        _imageRepository = imageRepository;
        _fileRepository = fileRepository;
    }

    public async Task<Product?> GetProductById(long productId)
    {
        return await _productRepository.GetProductById(productId);
    }
        public async Task<IQueryable<Product>?> GetAllProducts()
    {
        return await _productRepository.GetAllProducts();
    }
    public async Task<Product> CreateProduct(ProductDto productDto)
    {

        var images = productDto.FileUploadImages;
        var slug = productDto.ProductName.ToSlug();//get slug
        slug = await ChangeIfSlugAlreadyExists(slug);//change it if already exists

        var newProduct = InstantiateProduct(productDto, slug);

        await _productRepository.CreateNewProduct(newProduct);

        await _fileRepository.UploadFiles(images);
        // check if all files given are valid images
        foreach (var image in images)
        {
            if (_fileRepository.IsFileAnImage(image) == false) throw new FileIsNotAnImageException("Arquivo não é uma imagem.");
        }
        // if so continue
        foreach (var image in images)
        {
            if (image.Length > 0)
            {
                var fileName = await _fileRepository.UploadFile(image);
                await _productRepository.AddNewImageToProduct(fileName!, newProduct);
            }
        }

        return newProduct;
    }
    public async Task<Product?> AddImageToProduct(IFormFile image, long productId)
    {
        var product = await _productRepository.GetProductById(productId);

        if (product is null || image is null) return null;

        var fileIsImage = _fileRepository.IsFileAnImage(image);
        if (!fileIsImage) throw new FileIsNotAnImageException("Arquivo não é uma imagem.");

        var filePath = await _fileRepository.UploadFile(image);
        if (filePath is null) return null;

        return await _productRepository.AddNewImageToProduct(filePath, product);
    }
    public async Task<Product> EditProduct(long productToBeUpdatedId, ProductDto newProductDto)
    {
        var newProduct = InstantiateProduct(newProductDto);

        var updatedProduct = await _productRepository.UpdateProductById(productToBeUpdatedId, newProduct);
        return updatedProduct!;
    }

    public async Task<bool> RemoveProduct(long productId) =>
     await _productRepository.RemoveProductById(productId);
    public async Task<bool> RemoveImageFromProduct(long productId, long imageId)
    {
        var image = await _imageRepository.GetImageById(imageId);
        var product = await _productRepository.GetProductById(productId);


        if (image is null || product is null) return false;

        bool removedSuccess = _fileRepository.RemoveFile(image.Url);
        if (!removedSuccess) throw new DeleteFailedException("Não foi possível remover o arquivo.");

        return await _productRepository.RemoveImageFromProduct(product, image);
    }

    //helpers
    private async Task<string> ChangeIfSlugAlreadyExists(string slug)
    {
        var slugExists = await _productRepository.ProductSlugExists(slug);

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
    private Product InstantiateProduct(ProductDto productDto, string slug)
    {
        return new Product()
        {
            ProductName = productDto.ProductName,
            Price = productDto.Price,
            Description = productDto.Description,
            AvailableUnits = productDto.AvailableUnits,
            Slug = slug,
            Sku = productDto.Sku,
        };
    }

    private Product InstantiateProduct(ProductDto productDto)
    {
        return new Product()
        {
            ProductName = productDto.ProductName,
            Price = productDto.Price,
            Description = productDto.Description,
            AvailableUnits = productDto.AvailableUnits,
            Slug = productDto.Slug,
            Sku = productDto.Sku,
        };
    }
}