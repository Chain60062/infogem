namespace GroGem.Models;

public partial class Promo
{
    public int PromoId { get; set; }

    public string Code { get; set; } = null!;

    public decimal DicountValue { get; set; }

    public decimal? MinimumOrderValue { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ValidUntil { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
