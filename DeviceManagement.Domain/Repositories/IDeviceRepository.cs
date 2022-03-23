using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Repositories.Generic;

namespace DeviceManagement.Domain.Repositories
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        public Task<Device> GetDeviceByNameAsync(string name);

        public Task<IEnumerable<Device>> GetAllDevicesAsync();

        public Task<Device> GetDeviceByIdAsync(int id);

        public Task<bool> CheckIfExists(string name);

    }
}
