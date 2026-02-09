using Microsoft.EntityFrameworkCore;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Temperature.Infrastructure.Persistence.Repositories;

public class TemperatureRepository : ITemperatureRepository
{
    private readonly TemperatureDbContext _context;

    public TemperatureRepository(TemperatureDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TemperatureRecord record)
    {
        await _context.TemperatureRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TemperatureRecord>> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct)
    {
        return await _context.TemperatureRecords
            .AsNoTracking()
            .Where(x => x.DeviceId == deviceId)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync(ct);
    }

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
