namespace GroGem.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ApplicationUser User { get; set; } = null!;
}
