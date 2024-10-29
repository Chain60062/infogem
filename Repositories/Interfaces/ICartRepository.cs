using InfoGem.Models;

namespace InfoGem.Repositories;

public interface ICartRepository
{
    public Task<Cart?> GetUserCart(Guid userId);
    public Task<Cart?> GetCartById(long cartId);
    public Task<IQueryable<Product>?> GetCartProducts(long cartId);
    public Task<bool> RemoveCartById(long cartId);
    public Task<Cart?> CreateNewCart(Cart cart);
    public Task<Cart?> AddProductToCart(long cartId, long productId, int quantity);
}