using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace DataAccess;

public class FarmDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<UnitsOfMeasurement> UnitsOfMeasurements { get; set; }
    public DbSet<Harvest> Harvests { get; set; }
    public DbSet<Report> Reports { get; set; }

    public FarmDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
        
        modelBuilder.Entity<UserRating>()
            .HasOne(u => u.User)
            .WithMany(ur => ur.UserRatings)
            .HasForeignKey(u => u.UserId);

        modelBuilder.Entity<Product>()
            .HasOne(u => u.UnitsOfMeasurement)
            .WithMany(p => p.Products)
            .HasForeignKey(u => u.UoMId);

        modelBuilder.Entity<Harvest>()
            .HasOne(p => p.Product)
            .WithMany(h => h.Harvests)
            .HasForeignKey(p => p.ProductId);
        
        modelBuilder.Entity<Harvest>()
            .HasOne(u => u.User)
            .WithMany(h => h.Harvests)
            .HasForeignKey(u => u.UserId);

        modelBuilder.Entity<Report>()
            .HasOne(h => h.Harvest)
            .WithMany(r => r.Reports)
            .HasForeignKey(h => h.HarvestId);
    }
}