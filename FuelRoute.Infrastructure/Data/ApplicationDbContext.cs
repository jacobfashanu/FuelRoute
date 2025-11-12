using Microsoft.EntityFrameworkCore;
using FuelRoute.Core.Models;
using System.Reflection.Metadata;

namespace FuelRoute.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
    { }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Make).IsRequired();
            entity.Property(e => e.Model).IsRequired();
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.Fuel_efficiency).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Tank_capacity).IsRequired();
        });
    }

}