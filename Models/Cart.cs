using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Cart
{
    [Key]
    public long CartId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual Order Order { get; set; } = null!;
    public virtual AppUser User { get; set; } = null!;

    //Skip navigations
    public virtual ICollection<Product> Products { get; } = new HashSet<Product>();
    public virtual ICollection<CartProduct> CartProduct { get; } = new HashSet<CartProduct>();
}
