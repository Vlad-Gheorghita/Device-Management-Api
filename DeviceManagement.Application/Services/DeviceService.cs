using AutoMapper;
using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Device;
using DeviceManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public DeviceService(IDeviceRepository deviceRepository, IMapper mapper, IUserRepository userRepository)
        {
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<bool> AddDevice(DeviceCreateRequest deviceCreateRequest)
        {
            var device = mapper.Map<Device>(deviceCreateRequest);
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
            return mapper.Map<IEnumerable<DeviceResponse>>(devices);
        }

        public async Task<DeviceResponse> GetDeviceById(int id)
        {
            return mapper.Map<DeviceResponse>(await this.deviceRepository.GetDeviceByIdAsync(id));
        }

        public async Task<bool> UpdateDevice(DeviceUpdateRequest deviceUpdateRequest)
        {
            var device = await deviceRepository.GetById(deviceUpdateRequest.Id);
            var user = await userRepository.GetUserByIdAsync(deviceUpdateRequest.UserId);
            if (device == null)
                return false;

            device.Name = deviceUpdateRequest.Name;
            device.Manufacturer = deviceUpdateRequest.Manufacturer;
            device.Type = deviceUpdateRequest.Type;
            device.OperatingSystem = deviceUpdateRequest.OperatingSystem;
            device.OperatingSystemVersion = deviceUpdateRequest.OperatingSystemVersion;
            device.Processor = deviceUpdateRequest.Processor;
            device.User = user;

            return await deviceRepository.Edit(device);

        }
    }
}
