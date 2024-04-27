using Microsoft.AspNetCore.Mvc;
using InfoGem.Repositories;
using Microsoft.AspNetCore.Identity;
namespace InfoGem.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly ITagRepository _tagRepository;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthController(ILogger<AuthController> logger, ITagRepository tagRepository, SignInManager<AppUser> signInManager)
    {
        _logger = logger;
        _tagRepository = tagRepository;
        _signInManager = signInManager;
    }

    [HttpPost("/logout")]
    public async Task<IActionResult> Logout([FromBody] object empty)
    {
        if (empty is not null)
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        return Unauthorized();
    }
}
