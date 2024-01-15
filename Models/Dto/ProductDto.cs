namespace InfoGem.Dto;

public record ProductDto
{
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public string? Description { get; set; }
    public int AvailableUnits { get; set; }
    public string Slug { get; set; } = null!;
    public string? Sku { get; set; }
    public DateTime? DiscountStartAt { get; set; }
    public DateTime? DiscountEndsAt { get; set; }
    public IFormFileCollection FileUploadImages { get; set; } = null!;
}