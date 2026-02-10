using Microsoft.EntityFrameworkCore;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Movement.Infrastructure.Persistence.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly MovementDbContext _context;

    public MovementRepository(MovementDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MovementRecord record, CancellationToken ct)
    {
        await _context.MovementRecords.AddAsync(record);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<MovementRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct)
    {
        return await _context.MovementRecords
            .AsNoTracking()
            .Where(x => x.DeviceId == deviceId)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
    }
}
