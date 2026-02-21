using Microsoft.EntityFrameworkCore;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;
using PetMonitoring.Temperature.Infrastructure.Persistence;

namespace PetMonitoring.Temperature.Infrastructure.Repositories;

public class TemperatureRepository : ITemperatureRepository
{
    private readonly TemperatureDbContext _context;

    public TemperatureRepository(TemperatureDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TemperatureRecord record, CancellationToken ct)
    {
        await _context.TemperatureRecords.AddAsync(record);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<TemperatureRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct)
    {
        return await _context.TemperatureRecords
            .AsNoTracking()
            .Where(x => x.DeviceId == deviceId)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
    }

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
