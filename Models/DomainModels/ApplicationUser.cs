using Microsoft.AspNetCore.Identity;
using GroGem.Models;
public class ApplicationUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? MobilePhone { get; set; }
    public string? LandLine { get; set; }
    public string? IsVendor { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

}