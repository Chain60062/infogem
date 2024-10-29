using InfoGem.Services;
using Microsoft.AspNetCore.Mvc;
using InfoGem.Dto;
using Microsoft.AspNetCore.Authorization;

namespace InfoGem.Controllers;

[Authorize] //para adicionar autorização utilize Map{method}.RequireAuthorization() ou o atributo [Authorize]
[ApiController]
[Route("api/carts")]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var userIdGuid = new Guid(userId);

        var cart = await _cartService.GetUserCart(userIdGuid);

        return cart is null ? Ok(cart) : NotFound();
    }

    [HttpGet("{cartId}/products")]
    public async Task<IActionResult> GetCartProducts(long cartId)
    {
        var products = await _cartService.GetCartProducts(cartId);

        return products is null ? Ok(products) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CartDto cart)
    {
        var createdCart = await _cartService.CreateNewCart(cart.UserId);

        if (createdCart is null) return BadRequest();

        return CreatedAtAction("GetCart", createdCart.UserId, createdCart);
    }

    [HttpDelete("{cartid}")]
    public async Task<IActionResult> Remove(long cartId)
    {
        bool wasRemoved = await _cartService.RemoveCartById(cartId);

        if (wasRemoved == true) return NoContent();
        else return BadRequest();
    }
}

