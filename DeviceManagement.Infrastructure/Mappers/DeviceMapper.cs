

using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Mappers;
using DeviceManagement.Domain.Models.Device;

namespace DeviceManagement.Infrastructure.Mappers
{
    public class DeviceMapper : IDeviceMapper
    {
        private readonly IUserMapper userMapper;

        public DeviceMapper(IUserMapper userMapper)
        {
            this.userMapper = userMapper;
        }

        public DeviceResponse MapFromDevice(Device device)
        {
            return new DeviceResponse
            {
                Id = device.Id,
                Name = device.Name,
                Manufacturer = device.Manufacturer,
                Type = device.Type,
                OperatingSystem = device.OperatingSystem,
                OperatingSystemVersion = device.OperatingSystemVersion,
                Processor = device.Processor,
                RAM = device.RAM,
                User = this.userMapper.MapToUserResponse(device.User)
            };
        }

        public IEnumerable<DeviceResponse> MapFromDevice(IEnumerable<Device> devices)
        {
            return devices.Select(device => this.MapFromDevice(device)).ToList();
        }

        public Device MapToDevice(DeviceCreateRequest deviceCreateRequest)
        {
            return new Device
            {
                Name = deviceCreateRequest.Name,
                Manufacturer = deviceCreateRequest.Manufacturer,
                Type = deviceCreateRequest.Type,
                OperatingSystem = deviceCreateRequest.OperatingSystem,
                OperatingSystemVersion = deviceCreateRequest.OperatingSystemVersion,
                Processor = deviceCreateRequest.Processor,
                RAM = deviceCreateRequest.RAM,
            };
        }

        public Device MapUpdateDevice(DeviceUpdateRequest deviceUpdateRequest, Device device)
        {
            device.Name = deviceUpdateRequest.Name;
            device.Manufacturer = deviceUpdateRequest.Manufacturer;
            device.Type = deviceUpdateRequest.Type;
            device.OperatingSystem = deviceUpdateRequest.OperatingSystem;
            device.OperatingSystemVersion = deviceUpdateRequest.OperatingSystemVersion;
            device.Processor = deviceUpdateRequest.Processor;
            device.RAM = deviceUpdateRequest.RAM;

            return device;
        }
    }
}
