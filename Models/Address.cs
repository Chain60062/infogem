using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Address
{
    [Key]
    public long AddressId { get; set; }

    public string Cep { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string Neighborhood { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string? Complement { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    public Guid UserId { get; set; }
    public virtual AppUser User { get; set; } = null!;
}
