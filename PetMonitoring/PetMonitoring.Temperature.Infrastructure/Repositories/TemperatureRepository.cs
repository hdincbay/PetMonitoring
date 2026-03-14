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

    public async Task<string> AddAsync(TemperatureRecord record, CancellationToken ct)
    {
        var entry = await _context.TemperatureRecords.AddAsync(record);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? entry.Entity.Id.ToString() : string.Empty;
    }

    public async Task<TemperatureRecord?> GetByDeviceSerialNumberAsync(string deviceSerialNumber, CancellationToken ct)
    {
        return await _context.TemperatureRecords
            .AsNoTracking()
            .Where(x => x.DeviceSerialNumber == deviceSerialNumber)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
    }

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
