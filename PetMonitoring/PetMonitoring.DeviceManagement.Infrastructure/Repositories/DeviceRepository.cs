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

    public async Task<string?> CreateAsync(DeviceRecord record, CancellationToken ct)
    {
        var entry = await _context.DeviceRecords.AddAsync(record, ct);
        var affectedRows = await _context.SaveChangesAsync(ct);

        return affectedRows > 0 ? entry.Entity.SerialNumber : string.Empty;
    }
    public async Task<bool> UpdateAsync(DeviceRecord record, CancellationToken ct)
    {
        _context.DeviceRecords.Update(record);
        var affectedRows = await _context.SaveChangesAsync(ct);
        return affectedRows > 0;
    }
    public async Task<DeviceRecord?> GetByDeviceIdAsync(Guid deviceId, CancellationToken ct)
    {
        return await _context.DeviceRecords
            .Where(x => x.Id == deviceId && x.IsDeleted == false)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<DeviceRecord>?> GetAllAsync(CancellationToken ct)
    {
        return await _context.DeviceRecords.Where(x => x.IsDeleted == false).ToListAsync(ct);
    }

    public async Task<DeviceRecord?> GetBySerialNumberAsync(string serialNumber, CancellationToken ct)
    {
        return await _context.DeviceRecords
            .Where(x => x.SerialNumber == serialNumber && x.IsDeleted == false)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefaultAsync(ct);  
    }
}
