namespace GroGem.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public Guid UserId { get; set; }

    public string Cep { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string? City { get; set; }

    public string Street { get; set; } = null!;

    public string Neighborhood { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string? Complement { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ApplicationUser User { get; set; } = null!;
}
