using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Product
{
    [Key]
    public long ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? Sku { get; set; }

    public int AvailableUnits { get; set; }

    public string Slug { get; set; } = null!;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public long? DealId { get; set; } = null!;
    public virtual Deal Deal { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();

    //Skip navigations for many-to-many relationship
    public virtual ICollection<Tag> Tags { get; } = new HashSet<Tag>();

    //many-to-many with cart
    public virtual ICollection<Cart> Carts { get; } = new HashSet<Cart>();
    public virtual ICollection<CartProduct> CartProduct { get; } = new HashSet<CartProduct>();

    //many-to-many with category
    public virtual ICollection<Category> Categories { get; } = new List<Category>();
}
