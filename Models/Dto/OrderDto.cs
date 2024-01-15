using InfoGem.Enums;

namespace InfoGem.Dto;

public record class OrderDto{
    public long OrderId { get; set; }
    
    public Guid UserId { get; set; }
    
    public OrderStatus Status { get; set; }

    public long CartId { get; set; }

    public long AddressId { get; set; }

    public long? PromoId { get; set; }

    //total and grandtotal may be null initially
    public decimal? Total { get; set; }
    
    public decimal? GrandTotal { get; set; }

    public decimal Shipping { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string ShippingMethod { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
};