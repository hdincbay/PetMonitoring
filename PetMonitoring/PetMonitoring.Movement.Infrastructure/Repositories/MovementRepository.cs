using Microsoft.EntityFrameworkCore;
using PetMonitoring.Movement.Application.Interfaces;
using PetMonitoring.Movement.Domain.Entities;

namespace PetMonitoring.Health.Infrastructure.Persistence.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly MovementDbContext _context;

    public MovementRepository(MovementDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MovementRecord record)
    {
        await _context.HeartRateRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MovementRecord>> GetByPetIdAsync(Guid petId)
    {
        return await _context.HeartRateRecords
            .Where(x => x.PetId == petId)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }
}
