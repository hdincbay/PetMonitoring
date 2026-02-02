using Microsoft.EntityFrameworkCore;
using PetMonitoring.Movement.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetMonitoring.Health.Infrastructure.Persistence;

public class MovementDbContext : DbContext
{
    public MovementDbContext(DbContextOptions<MovementDbContext> options)
        : base(options)
    {
    }

    public DbSet<MovementRecord> HeartRateRecords => Set<MovementRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovementRecord>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasIndex(x => new { x.PetId, x.CreatedDate });

            entity.Property(x => x.CreatedDate)
                  .IsRequired();
        });
    }
}
