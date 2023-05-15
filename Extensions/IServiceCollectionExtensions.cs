using GroGem.Services;
public static class IServiceCollectionExtensions
{
    public static void AddServicesLayer(this IServiceCollection services)
    {
        services.AddScoped<ProductService>();
        services.AddScoped<CategoryService>();
    }
}