using Microsoft.EntityFrameworkCore;
using PetMonitoring.Movement.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetMonitoring.Movement.Infrastructure.Persistence;

public class MovementDbContext : DbContext
{
    public MovementDbContext(DbContextOptions<MovementDbContext> options)
        : base(options)
    {
    }

    public DbSet<MovementRecord> MovementRecords => Set<MovementRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovementRecord>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.CreatedDate)
                  .IsRequired();
        });
    }
}
