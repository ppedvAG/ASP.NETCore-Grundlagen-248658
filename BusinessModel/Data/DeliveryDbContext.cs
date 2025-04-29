using BusinessModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data;

public class DeliveryDbContext : IdentityDbContext
{
    // Allen DbSets steht jeweils eine Tabelle gegenueber
    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Recipe> Recipes { get; set; }

    // Dieser Konstruktur ist wichtig um den DbContext erzeugen zu koennen
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Seed.SeedIdentity(modelBuilder);

        Seed.SeedDeliveryData(modelBuilder);
    }
}
