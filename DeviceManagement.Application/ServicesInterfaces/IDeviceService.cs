using DeviceManagement.Domain.Models.Device;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface IDeviceService
    {
        public Task<IEnumerable<DeviceResponse>> GetAllDevices();

        public Task<DeviceResponse> GetDeviceById(int id);

        public Task<bool> AddDevice(DeviceCreateRequest deviceCreateRequest);

        public Task<bool> DeleteDevice(int id);

        public Task<bool> UpdateDevice(DeviceUpdateRequest deviceUpdateRequest);

        public Task<DeviceResponse> UpdateDeviceUser(int deviceId, int userId);
    }
}
