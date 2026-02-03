using Microsoft.EntityFrameworkCore;
using PetMonitoring.Temperature.Application.Interfaces;
using PetMonitoring.Temperature.Domain.Entities;

namespace PetMonitoring.Health.Infrastructure.Persistence.Repositories;

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

    public async Task<IEnumerable<TemperatureRecord>> GetByPetIdAsync(Guid petId)
    {
        return await _context.TemperatureRecords
            .Where(x => x.PetId == petId)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }
}
