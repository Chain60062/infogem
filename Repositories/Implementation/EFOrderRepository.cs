using InfoGem.Data;
using InfoGem.Enums;
using InfoGem.Exceptions;
using InfoGem.Models;

namespace InfoGem.Repositories;
public class EFOrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public EFOrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> CancelOrderById(long orderId)
    {
        var order = await _db.Orders.FindAsync(orderId);

        if (order is null) throw new NotFoundException("Pedido não existe.");

        if (order.Status != OrderStatus.Pending)
            throw new ForbiddenOperationException("Pedido já confirmado, não pode ser cancelado.");

        order.Status = OrderStatus.Cancelled;

        var result = await _db.SaveChangesAsync();

        return result > 0 ? true : false;
    }

    public async Task<Order?> CreateOrder(Order order, Cart cart)
    {

        var total = GetTotal(order);
        var grandTotal = GetGrandTotal(order);

        order.Total = total;
        order.GrandTotal = grandTotal;
        order.Cart = cart;

        await _db.Orders.AddAsync(order);

        await _db.SaveChangesAsync();

        return order;
    }

    public async Task<Order?> GetCartOrder(long cartId)
    {
        var cart = await _db.Carts.FindAsync(cartId);

        if (cart is null) throw new NotFoundException("Carrinho não encontrado.");

        return cart.Order;
    }

    public async Task<Order?> GetOrderById(long orderId) => await _db.Orders.FindAsync(orderId);

    public  IQueryable<Order>? GetUserOrders(AppUser user)=> user.Orders.AsQueryable();

    private decimal GetGrandTotal(Order order)
    {
        decimal sum = 0;
        var cartProducts = order.Cart?.Products.ToList();

        foreach (var product in cartProducts!)
        {
            sum += product.Price;
        }

        return sum;
    }
    private decimal GetTotal(Order order)
    {
        decimal sum = 0, grandTotal = 0, discount;

        var cartProducts = order.Cart?.Products.ToList();

        foreach (var product in cartProducts!)
        {
            sum += product.Deal.DiscountPercentage / 100 * product.Price;
            grandTotal += product.Price;
        }

        discount = (order.Promo.DiscountPercentage / 100 * grandTotal) - grandTotal;
        sum -= discount;
        sum += order.Shipping;

        return sum;
    }
}