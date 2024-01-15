using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public partial class Category
{
    [Key]
    public long CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    //many-to-many with category
    public ICollection<Product> Products {get; set;} = new List<Product>();

}
