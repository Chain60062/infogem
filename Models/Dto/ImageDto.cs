namespace InfoGem.Dto;

public record class ImageDto
{
    public string Url { get; set; } = null!;

    public string? AltText { get; set; }

    public IFormFile? imageFile { get; set; }
}
