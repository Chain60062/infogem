using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Review
{
    [Key]
    public long ReviewId { get; set; }

    public long? ProductId { get; set; }

    public Guid UserId { get; set; }
    public string? Title { get; set; }

    public string? Text { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual AppUser User { get; set; } = null!;
}
