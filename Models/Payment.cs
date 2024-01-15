using System.ComponentModel.DataAnnotations;
using InfoGem.Enums;

namespace InfoGem.Models;

public class Payment
{
    [Key]
    public long PaymentId { get; set; }

    public Guid UserId { get; set; }

    public long OrderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public PaymentStatus Status { get; set; }

    public PaymentType Type { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
