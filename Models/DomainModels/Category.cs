namespace GroGem.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<Product> Products {get; set;} = new List<Product>();
}
