using Microsoft.EntityFrameworkCore;
using PetMonitoring.Health.Application.Interfaces;
using PetMonitoring.Health.Domain.Entities;

namespace PetMonitoring.Health.Infrastructure.Persistence.Repositories;

public class HeartRateRepository : IHeartRateRepository
{
    private readonly HealthDbContext _context;

    public HeartRateRepository(HealthDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(HeartRateRecord record)
    {
        await _context.HeartRateRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<HeartRateRecord>> GetByPetIdAsync(Guid petId)
    {
        return await _context.HeartRateRecords
            .Where(x => x.PetId == petId)
            .OrderByDescending(x => x.MeasuredAt)
            .ToListAsync();
    }
}
