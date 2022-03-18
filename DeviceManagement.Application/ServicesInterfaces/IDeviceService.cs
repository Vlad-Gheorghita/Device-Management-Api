using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface IDeviceService
    {
        public Task<IEnumerable<DeviceResponse>> GetAllDevices();
        public Task<DeviceResponse> GetDeviceById(int id);

        public Task<bool> AddDevice(DeviceCreateRequest deviceCreateRequest);
        public Task<bool> DeleteDevice(int id);
        public Task<bool> UpdateDevice(DeviceUpdateRequest deviceUpdateRequest);
    }
}
