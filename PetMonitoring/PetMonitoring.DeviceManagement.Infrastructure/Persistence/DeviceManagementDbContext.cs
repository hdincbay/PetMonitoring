using Microsoft.EntityFrameworkCore;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetMonitoring.DeviceManagement.Infrastructure.Persistence;

public class DeviceManagementDbContext : DbContext
{
    public DeviceManagementDbContext(DbContextOptions<DeviceManagementDbContext> options)
        : base(options)
    {
    }

    public DbSet<DeviceRecord> DeviceRecords => Set<DeviceRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceRecord>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasIndex(x => new { x.PetId, x.CreatedDate });

            entity.Property(x => x.CreatedDate)
                  .IsRequired();
        });
    }
}
