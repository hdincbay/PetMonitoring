using Microsoft.EntityFrameworkCore;
using PetMonitoring.DeviceManagement.Application.Interfaces;
using PetMonitoring.DeviceManagement.Domain.Entities;
using PetMonitoring.DeviceManagement.Infrastructure.Persistence;

namespace PetMonitoring.DeviceManagement.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly DeviceManagementDbContext _context;

    public DeviceRepository(DeviceManagementDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(DeviceRecord record, CancellationToken ct)
    {
        await _context.DeviceRecords.AddAsync(record);
        await _context.SaveChangesAsync(ct);
    }
    public async Task UpdateAsync(DeviceRecord record, CancellationToken ct)
    {
        _context.DeviceRecords.Update(record);
        await _context.SaveChangesAsync(ct);
    }
    public async Task<DeviceRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct)
    {
        return await _context.DeviceRecords
            .Where(x => x.Id == deviceId)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
    }
}
