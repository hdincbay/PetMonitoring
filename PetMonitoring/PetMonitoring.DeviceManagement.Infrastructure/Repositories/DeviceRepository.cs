using Microsoft.EntityFrameworkCore;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;

namespace PetMonitoring.DeviceManagement.Infrastructure.Persistence.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly DeviceManagementDbContext _context;

    public DeviceRepository(DeviceManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DeviceRecord record)
    {
        await _context.DeviceRecords.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DeviceRecord>> GetByPetIdAsync(Guid petId)
    {
        return await _context.DeviceRecords
            .Where(x => x.PetId == petId)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }
}
