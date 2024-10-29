using InfoGem.Data;
using InfoGem.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Repositories;

public class EFCartRepository : ICartRepository
{
    private readonly AppDbContext _db;

    public EFCartRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Cart?> CreateNewCart(Cart cart)
    {
        await _db.Carts.AddAsync(cart);
        await _db.SaveChangesAsync();
        return cart;
    }

    public async Task<Cart?> GetCartById(long cartId) => await _db.Carts.FindAsync(cartId);


    public async Task<Cart?> GetUserCart(Guid userId)
    {
        var user = await _db.Users.FindAsync(userId);

        if (user is null) return null;

        return user?.Carts.FirstOrDefault();
    }

    public async Task<IQueryable<Product>?> GetCartProducts(long cartId)
    {
        var cart = await _db.Carts.FindAsync(cartId);

        if (cart is null) return null;

        return cart.Products.AsQueryable();
    }

    public async Task<bool> RemoveCartById(long cartId)
    {
        try
        {
            var cart = await _db.Carts.FindAsync(cartId);

            if (cart is null) return false;

            _db.Carts.Remove(cart);
            await _db.SaveChangesAsync();

            return true;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task<Cart?> AddProductToCart(long productId, long cartId, int quantity = 1)
    {
        var product = await _db.Products.FindAsync(productId);
        var cart = await _db.Carts.FindAsync(cartId);

        if (cart is null || product is null) return null;

        var cartProduct = new CartProduct
        {
            Cart = cart,
            Product = product,
            Quantity = quantity
        };

        cart.CartProduct.Add(cartProduct);

        await _db.SaveChangesAsync();

        return cart;
    }

    // public async Task<Cart?> RemoveProductToCart(long productId, long cartId, int quantity = 1)
    // {
    //     var cartProduct = await _db.CartProduct
    //        .Where(cp => cp.CartId == cartId && cp.ProductId == productId)
    //        .SingleOrDefaultAsync();

    //     if (cartProduct != null)
    //     {
    //         _db.CartProducts.Remove(cartProduct);
    //         await _db.SaveChangesAsync();
    //     }

    //     return cart;
    // }
}