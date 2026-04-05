using Microsoft.EntityFrameworkCore;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;
using PetMonitoring.Movement.Infrastructure.Persistence;

namespace PetMonitoring.Movement.Infrastructure.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly MovementDbContext _context;

    public MovementRepository(MovementDbContext context)
    {
        _context = context;
    }

    public async Task<string> AddAsync(MovementRecord record, CancellationToken ct)
    {
        var entry = await _context.MovementRecords.AddAsync(record);
        var affectedRows = await _context.SaveChangesAsync();
        return affectedRows > 0 ? entry.Entity.Id.ToString() : string.Empty;
    }

    public async Task<List<MovementRecord>?> GetByDeviceSerialNumberAsync(string deviceSerialNumber, CancellationToken ct)
    {
        return await _context.MovementRecords
            .AsNoTracking()
            .Where(x => x.DeviceSerialNumber == deviceSerialNumber)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync(ct);
    }
}
