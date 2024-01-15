using System.ComponentModel.DataAnnotations;
using InfoGem.Enums;

namespace InfoGem.Models;

public partial class Order
{
    [Key]
    public long OrderId { get; set; }
    public OrderStatus Status { get; set; }

    public long? AddressId { get; set; }
    public Guid UserId { get; set; }

    public long? PromoId { get; set; }

    public decimal Total { get; set; }

    public decimal Shipping { get; set; }

    public decimal? GrandTotal { get; set; }


    public string? PromoCode { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Address? Address { get; set; }

    public long? CartId { get; set; }
    public virtual Cart? Cart { get; set; }

    public virtual Coupon Promo { get; set; } = null!;
    //an order can have
    public virtual Payment Payment { get; set; } = null!;
    public virtual AppUser User { get; set; } = null!;

}
