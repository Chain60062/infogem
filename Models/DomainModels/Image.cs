namespace GroGem.Models;

public partial class Image
{
    public int? ImageId { get; set; }

    public int? ProductId { get; set; }

    public string Url { get; set; } = null!;

    public string? AltText { get; set; }

    public virtual Product? Product { get; set; }
}
