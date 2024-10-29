using InfoGem.Services;
using InfoGem.Repositories;

namespace Infogem.Utils;
public static class IServiceCollectionExtensions
{
    public static void AddRepositoryAndServiceLayers(this IServiceCollection services)
    {
        // service layer
        services.AddScoped<ProductService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<CartService>();
        services.AddScoped<AddressService>();
        services.AddScoped<ImageService>();
        services.AddScoped<ReviewService>();
        services.AddScoped<OrderService>();
        services.AddScoped<PaymentService>();
        services.AddScoped<TagService>();
        // repository layer
        services.AddScoped<IProductRepository, EFProductRepository>();
        services.AddScoped<ICategoryRepository, EFCategoryRepository>();
        services.AddScoped<ICartRepository, EFCartRepository>();
        services.AddScoped<IAddressRepository, EFAddressRepository>();
        services.AddScoped<IFileRepository, EFFileRepository>();
        services.AddScoped<IImageRepository, EFImageRepository>();
        services.AddScoped<IReviewRepository, EFReviewRepository>();
        services.AddScoped<IOrderRepository, EFOrderRepository>();
        services.AddScoped<IPaymentRepository, EFPaymentRepository>();
        services.AddScoped<ITagRepository, EFTagRepository>();
    }
}