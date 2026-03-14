using Microsoft.EntityFrameworkCore;
using PetMonitoring.Temperature.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetMonitoring.Temperature.Infrastructure.Persistence;

public class TemperatureDbContext : DbContext
{
    public TemperatureDbContext(DbContextOptions<TemperatureDbContext> options)
        : base(options)
    {
    }

    public DbSet<TemperatureRecord> TemperatureRecords => Set<TemperatureRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
