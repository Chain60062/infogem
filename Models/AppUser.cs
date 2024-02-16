using Microsoft.AspNetCore.Identity;
using InfoGem.Models;
using System.ComponentModel.DataAnnotations;
public class AppUser : IdentityUser<Guid>
{
    public string? Cpf { get; set; }
    public string? Cnpj { get; set; }
    public bool IsVendor { get; set; }
    [Required(ErrorMessage = "Data de nascimento é obrigatória")]
    public DateOnly BirthDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}