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

        List<Product> products = new List<Product>();

        for (int i = 1; i <= 1000; i++)
        {
            products.Add(new Product
            {
                ProductId = i,
                AvailableUnits = 10,
                Description = "MOCK DESCRIPTION",
                Price = 10_000,
                ProductName = "MOCK PRODUCT NAME",
                Sku = Guid.NewGuid().ToString(),
                Slug = "mock" + i,
            });
        }

        builder.Entity<Product>().HasData(products.ToArray());
    }
}