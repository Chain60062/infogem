using GroGem.Models;
namespace GroGem.ViewModels;

public record ProductViewModel
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
    public int CategoryId { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
    public IFormFileCollection FileUploadImages { get; set; }

}