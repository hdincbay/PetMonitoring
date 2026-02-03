using Microsoft.EntityFrameworkCore;
using PetMonitoring.Temperature.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetMonitoring.Health.Infrastructure.Persistence;

public class TemperatureDbContext : DbContext
{
    public TemperatureDbContext(DbContextOptions<TemperatureDbContext> options)
        : base(options)
    {
    }

    public DbSet<TemperatureRecord> TemperatureRecords => Set<TemperatureRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TemperatureRecord>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasIndex(x => new { x.PetId, x.CreatedDate });

            entity.Property(x => x.CelsiusValue)
                  .IsRequired();

            entity.Property(x => x.CreatedDate)
                  .IsRequired();
        });
    }
}
