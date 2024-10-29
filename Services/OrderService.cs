using InfoGem.Dto;
using InfoGem.Models;
using InfoGem.Repositories;
using Microsoft.AspNetCore.Identity;

namespace InfoGem.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    private readonly UserManager<AppUser> _userManager;

    public OrderService(IOrderRepository orderRepository, UserManager<AppUser> userManager, ICartRepository cartRepository)
    {
        _orderRepository = orderRepository;
        _userManager = userManager;
        _cartRepository = cartRepository;
    }

    public async Task<IQueryable<Order>?> GetUserOrders(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null) return null;

        return  _orderRepository.GetUserOrders(user);
    }

    public async Task<Order?> CreateNewOrder(OrderDto orderDto)
    {
        var cart = await _cartRepository.GetCartById(orderDto.CartId);

        var order = InstantiateOrder(orderDto);

        if (cart is null) return null;

        return await _orderRepository.CreateOrder(order, cart);
    }

    public async Task<bool?> CancelOrder(long orderId) => await _orderRepository.CancelOrderById(orderId);

    private Order InstantiateOrder(OrderDto orderDto)
    {

        return new Order()
        {
            PaymentMethod = orderDto.PaymentMethod,
            ShippingMethod = orderDto.ShippingMethod,
            Shipping = orderDto.Shipping,
            Status = Enums.OrderStatus.Pending,
            AddressId = orderDto.AddressId,
            UserId = orderDto.UserId,
            PromoId = orderDto.PromoId,
            CartId = orderDto.CartId,
        };
    }
}