using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetMonitoring.Health.Infrastructure.Persistence;
public class HealthDbContext : DbContext
{
    public HealthDbContext(DbContextOptions<HealthDbContext> options)
        : base(options)
    {
    }

    public DbSet<HeartRateRecord> HeartRateRecords => Set<HeartRateRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
