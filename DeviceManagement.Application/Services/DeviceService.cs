using AutoMapper;
using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Mappers;
using DeviceManagement.Domain.Models.Device;
using DeviceManagement.Domain.Repositories;

namespace DeviceManagement.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IDeviceMapper deviceMapper;

        public DeviceService(IDeviceRepository deviceRepository, IMapper mapper, IUserRepository userRepository, IDeviceMapper deviceMapper)
        {
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.deviceMapper = deviceMapper;
        }

        public async Task<bool> AddDevice(DeviceCreateRequest deviceCreateRequest)
        {
            if (await deviceRepository.CheckIfExists(deviceCreateRequest.Name))
                return false;
            //var device = mapper.Map<Device>(deviceCreateRequest);
            var device = this.deviceMapper.MapToDevice(deviceCreateRequest);

            return await deviceRepository.Add(device);
        }

        public async Task<bool> DeleteDevice(int id)
        {
            var device = await deviceRepository.GetById(id);
            return await deviceRepository.Delete(device);
        }

        public async Task<IEnumerable<DeviceResponse>> GetAllDevices()
        {
            var devices = await deviceRepository.GetAllDevicesAsync();
            //return mapper.Map<IEnumerable<DeviceResponse>>(devices);

            return this.deviceMapper.MapFromDevice(devices);
        }

        public async Task<DeviceResponse> GetDeviceById(int id)
        {
            //return mapper.Map<DeviceResponse>(await this.deviceRepository.GetDeviceByIdAsync(id));
            return this.deviceMapper.MapFromDevice(await deviceRepository.GetDeviceByIdAsync(id));
        }

        public async Task<bool> UpdateDevice(DeviceUpdateRequest deviceUpdateRequest)
        {
            var device = await deviceRepository.GetById(deviceUpdateRequest.Id);
            if (device == null)
                return false;

            //device.Name = deviceUpdateRequest.Name;
            //device.Manufacturer = deviceUpdateRequest.Manufacturer;
            //device.Type = deviceUpdateRequest.Type;
            //device.OperatingSystem = deviceUpdateRequest.OperatingSystem;
            //device.OperatingSystemVersion = deviceUpdateRequest.OperatingSystemVersion;
            //device.Processor = deviceUpdateRequest.Processor;

            

            return await deviceRepository.Edit(this.deviceMapper.MapUpdateDevice(deviceUpdateRequest,device));

        }

        public async Task<DeviceResponse> UpdateDeviceUser(int deviceId, int userId)
        {

            var device = await deviceRepository.GetDeviceByIdAsync(deviceId);
            if (device == null)
                return null;

            if (userId == 0)
            {
                device.User = null;
                if (!(await deviceRepository.Edit(device)))
                    return null;
                //return mapper.Map<DeviceResponse>(device);
                return this.deviceMapper.MapFromDevice(device);
            }

            if (device.User != null)
                return null;

            var user = await userRepository.GetUserByIdAsync(userId);

            if (user == null)
                return null;

            device.User = user;

            if (!(await deviceRepository.Edit(device)))
                return null;

            //return mapper.Map<DeviceResponse>(device);
            return this.deviceMapper.MapFromDevice(device);
        }
    }
}
