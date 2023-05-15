namespace GroGem.Models;

public partial class Order
{
    public enum OrderStatus{
        Pending,
        Confirmed,
        Shipped,
        Delivered
    }
    public OrderStatus Status { get; set; }
    public int OrderId { get; set; }

    public Guid UserId { get; set; }

    public int? CartId { get; set; }

    public int? AddressId { get; set; }

    public int? PromoId { get; set; }

    public decimal Total { get; set; }

    public decimal Shipping { get; set; }

    public decimal? GrandTotal { get; set; }

    public decimal? Discount { get; set; }

    public string? PromoCode { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Promo? Promo { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ApplicationUser User { get; set; } = null!;
}
