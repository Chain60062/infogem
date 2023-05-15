namespace GroGem.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public string? Description { get; set; }

    public string? Sku { get; set; }

    public int AvailableUnits { get; set; }

    public string Slug { get; set; } = null!;

    public DateTime? DiscountStartAt { get; set; }

    public DateTime? DiscountEndsAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
