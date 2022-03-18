using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Device;
using DeviceManagement.Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Repositories
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        public Task<Device> GetDeviceByNameAsync(string name);
        public Task<IEnumerable<Device>> GetAllDevicesAsync();
        public Task<Device> GetDeviceByIdAsync(int id);

    }
}
