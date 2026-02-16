using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;
using PetMonitoring.Health.Infrastructure.Persistence;
public sealed class HeartRateRepository : IHeartRateRepository
{
    private readonly HealthDbContext _context;

    public HeartRateRepository(HealthDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(HeartRateRecord record, CancellationToken ct)
    {
        await _context.HeartRateRecords.AddAsync(record, ct);
        await _context.SaveChangesAsync();
    }

    public async Task<HeartRateRecord?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.HeartRateRecords
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<HeartRateRecord?> GetByDeviceSerialNumberAsync(string deviceSerialNumber, CancellationToken ct)
    {
        return await _context.HeartRateRecords
            .AsNoTracking()
            .Where(x => x.DeviceSerialNumber == deviceSerialNumber)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
    }
}
