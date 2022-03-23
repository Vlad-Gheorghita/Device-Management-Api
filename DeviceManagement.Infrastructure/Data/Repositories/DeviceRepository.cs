using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Repositories;
using DeviceManagement.Infrastructure.Data.Generic;
using DeviceManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace DeviceManagement.Infrastructure.Data.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DeviceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckIfExists(string name)
        {
            return await dbContext.Devices.AnyAsync(d => d.Name == name);
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            return await dbContext.Devices.Include(d => d.User).ToListAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            return await dbContext.Devices.Include(d => d.User).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Device> GetDeviceByNameAsync(string name)
        {
            return await dbContext.Devices.FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
