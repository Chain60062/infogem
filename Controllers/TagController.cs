using Microsoft.AspNetCore.Mvc;
using InfoGem.Services;
using Microsoft.EntityFrameworkCore;
using InfoGem.Dto;

namespace InfoGem.Controllers;

[Route("api/tags")]
[ApiController]
public class TagController : Controller
{
    private readonly TagService _tagService;
    public TagController(TagService tagService)
    {
        _tagService = tagService;
    }
    [Route("{tagId}")]
    [HttpGet]
    public async Task<IActionResult> GetTag(long tagId)
    {
        var tag = await _tagService.GetTag(tagId);

        if (tag is null) return NotFound();

        return Ok(tag);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTag([FromBody] TagDto tagDto)
    {
        var tag = await _tagService.CreateNewTag(tagDto);

        if (tag is null) return BadRequest();

        return CreatedAtAction("GetTag", tag.TagId, tag);
    }
    [HttpPut]
    public async Task<IActionResult> EditTag([FromBody] TagDto tagDto, long tagId)
    {
        try
        {
            var tag = await _tagService.UpdateTagById(tagId, tagDto);

            if (tag is null) return NotFound();

            return Ok(tag);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao editar produto.");
        }
    }
    [HttpDelete("{tagId}")]
    public async Task<IActionResult> RemoveTag(long tagId)
    {
        try
        {
            var tag = await _tagService.RemoveTag(tagId);

            if (tag == false) return NotFound();

            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, "Falha ao remover produto.");
        }
    }
}