using GroGem.Models;

namespace GroGem.ViewModels;

public record CategoryViewModel
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = new List<Product>();

}