using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Deal
{
    [Key]
    public long DealId { get; set; }

    public short DiscountPercentage { get; set; }

    public decimal? MinimumOrderValue { get; set; }

    public DateTime DiscountStartsAt { get; set; }
    public DateTime DiscountEndsAt { get; set; }
    //many-to-many with product
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
