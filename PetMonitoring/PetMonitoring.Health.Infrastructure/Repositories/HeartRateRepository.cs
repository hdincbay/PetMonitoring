using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;
using PetMonitoring.Health.Infrastructure.Persistence;

namespace PetMonitoring.Health.Infrastructure.Repositories;

public sealed class HeartRateRepository : IHeartRateRepository
{
    private readonly HealthDbContext _context;

    public HeartRateRepository(HealthDbContext context)
    {
        _context = context;
    }

    public async Task<string> AddAsync(HeartRateRecord record, CancellationToken ct)
    {
        var entry = await _context.HeartRateRecords.AddAsync(record, ct);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? entry.Entity.Id.ToString() : string.Empty;
    }
    public async Task<List<HeartRateRecord>?> GetByDeviceSerialNumberAsync(string deviceSerialNumber, CancellationToken ct)
    {
        return await _context.HeartRateRecords
            .AsNoTracking()
            .Where(x => x.DeviceSerialNumber == deviceSerialNumber)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync(ct);
    }
}
