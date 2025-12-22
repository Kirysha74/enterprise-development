using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<ModelGeneration> ModelGenerations { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.ModelGeneration)
                  .WithMany()
                  .HasForeignKey(c => c.ModelGenerationId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ModelGeneration>(entity =>
        {
            entity.HasKey(mg => mg.Id);
            entity.HasOne(mg => mg.Model)
                  .WithMany()
                  .HasForeignKey(mg => mg.ModelId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.HasOne(r => r.Car)
                  .WithMany()
                  .HasForeignKey(r => r.CarId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(r => r.Client)
                  .WithMany()
                  .HasForeignKey(r => r.ClientId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Client>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<CarModel>()
            .HasKey(cm => cm.Id);
    }
}