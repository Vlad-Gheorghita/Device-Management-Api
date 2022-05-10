using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Device;

namespace DeviceManagement.Domain.Mappers
{
    public interface IDeviceMapper
    {
        public Device MapToDevice(DeviceCreateRequest deviceCreateRequest);
        public Device MapUpdateDevice(DeviceUpdateRequest deviceUpdateRequest, Device device);
        public DeviceResponse MapFromDevice(Device device);
        public IEnumerable<DeviceResponse> MapFromDevice(IEnumerable<Device> devices);
    }
}