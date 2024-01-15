using Microsoft.AspNetCore.Mvc;
using InfoGem.Repositories;
namespace InfoGem.Controllers;

[Route("api")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITagRepository _tagRepository;

    public HomeController(ILogger<HomeController> logger, ITagRepository tagRepository)
    {
        _logger = logger;
        _tagRepository = tagRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Home()
    {
        return Ok("Funciona");
    }
}
