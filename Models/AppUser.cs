using Microsoft.AspNetCore.Identity;
using InfoGem.Models;
public class AppUser : IdentityUser<Guid>
{
    public string? Cpf { get; set; }
    public string? Cnpj { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? MobilePhone { get; set; }
    public string? LandLine { get; set; }
    public string? IsVendor { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}