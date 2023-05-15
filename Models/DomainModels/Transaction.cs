using System.ComponentModel.DataAnnotations;

namespace GroGem.Models;

public partial class Transaction
{
    public enum TransactionStatus
    {
        New,
        Pending,
        Cancelled,
        Declined,
        Success
    }
    public enum TransactionMode
    {
        Online,
        PayOnDelivery
    }
    public enum TransactionType
    {
        Credit,
        Debit,
        Pix
    }
    public int TransactionId { get; set; }

    public Guid UserId { get; set; }

    public int? OrderId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public TransactionStatus Status { get; set; }

    public TransactionType Type { get; set; }

    public TransactionMode Mode { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}
