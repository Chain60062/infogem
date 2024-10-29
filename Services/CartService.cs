using InfoGem.Models;
using InfoGem.Repositories;

namespace InfoGem.Services;

public class CartService
{
    private readonly ICartRepository _cartRepository;
    private static readonly Random random = new Random();
    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<Cart?> GetUserCart(Guid userId)
    {
        return await _cartRepository.GetUserCart(userId);
    }
    public async Task<Cart?> GetCartById(long cartId)
    {
        return await _cartRepository.GetCartById(cartId);
    }

    public async Task<IQueryable<Product>?> GetCartProducts(long cartId)
    {
        return await _cartRepository.GetCartProducts(cartId);
    }

    public Task<bool> RemoveCartById(long cartId)
    {
        return _cartRepository.RemoveCartById(cartId);
    }

    public async Task<Cart?> AddProductToCart(long cartId, long productId, int quantity)
    {
        return await _cartRepository.AddProductToCart(cartId, productId, quantity);
    }
    public async Task<Cart?> CreateNewCart(Guid userId)
    {

        // var userClaimsPrincipal = _httpContextAccessor.HttpContext?.User;
        // if (userClaimsPrincipal is null) return null;
        // var userId = new Guid(userClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var cart = new Cart
        {
            UserId = userId
        };

        return await _cartRepository.CreateNewCart(cart);
    }
}