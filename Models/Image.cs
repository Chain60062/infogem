using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Image
{
    [Key]
    public long ImageId { get; set; }

    public long? ProductId { get; set; }

    public string Url { get; set; } = null!;

    public string? AltText { get; set; }

    public bool IsMain { get; set; }

    public virtual Product? Product { get; set; }
}
