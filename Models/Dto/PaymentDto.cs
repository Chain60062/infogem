using InfoGem.Enums;

namespace InfoGem.Dto;
public record struct PaymentDto(){
    public long PaymentId { get; set; }

    public Guid UserId { get; set; }

    public long OrderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public PaymentStatus Status { get; set; }

    public PaymentType Type { get; set; }
}