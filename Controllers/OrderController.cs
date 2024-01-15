using Microsoft.AspNetCore.Mvc;
using InfoGem.Services;
using InfoGem.Dto;
using Microsoft.EntityFrameworkCore;

namespace InfoGem.Controllers;

public class OrderController : Controller
{
    private readonly OrderService _orderService;
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger, OrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [Route("{OrderId}")]
    [HttpGet]
    public async Task<IActionResult> GetOrder(string userId)
    {
        var order = await _orderService.GetUserOrders(userId);

        if (order is null) return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
    {
        var order = await _orderService.CreateNewOrder(orderDto);

        if (order is null) return BadRequest();

        return CreatedAtAction("GetOrder", order.OrderId, order);
    }

    [HttpDelete("{OrderId}")]
    public async Task<IActionResult> RemoveOrder(long orderId)
    {
        try
        {
            var order = await _orderService.CancelOrder(orderId);

            if (order == false) return NotFound();

            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao remover produto.");
        }
    }
}
