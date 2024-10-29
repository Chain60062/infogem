using InfoGem.Models;

namespace InfoGem.Repositories;

public interface IOrderRepository
{
    public Task<Order?> CreateOrder(Order order, Cart cart);
    public Task<Order?> GetCartOrder(long cartId);
    public IQueryable<Order>? GetUserOrders(AppUser user);
    public Task<Order?> GetOrderById(long orderId);
    public Task<bool> CancelOrderById(long orderId);
}