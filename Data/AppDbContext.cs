using Microsoft.EntityFrameworkCore;
using InfoGem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace InfoGem.Data;

public partial class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<CartProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Coupon> Promos { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var product1 = new Product()
        {
            ProductId = 1,
            AvailableUnits = 12,
            Description = "Apple Iphone 15",
            Price = 12_200,
            ProductName = "IPhone 15",
            Sku = "ACZZH34M",
            Slug = "iphone-15",
        };
        var product2 = new Product()
        {
            ProductId = 2,
            AvailableUnits = 1200,
            Description = "SSD Kingston com capacidade 256GB",
            Price = 12_200,
            ProductName = "SSD Kingston 256GB",
            Sku = "CASDGA23J",
            Slug = "ssd-kingston-256gb",
        };
        
        builder.Entity<Product>().HasData(product1, product2);
    }
}