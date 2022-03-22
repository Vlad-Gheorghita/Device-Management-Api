using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManagement.Domain.Models.Location;

namespace DeviceManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IDeviceRepository deviceRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IDeviceRepository deviceRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            var devices = await deviceRepository.GetAllDevicesAsync();

            return await userRepository.Delete(user);
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {

            return mapper.Map<IEnumerable<UserResponse>>(userRepository.GetAll());

        }

        public async Task<UserResponse> GetUserById(int id)
        {
            return mapper.Map<UserResponse>(await userRepository.GetUserByIdAsync(id));
        }

        public async Task<UserResponse> GetUserByName(string name)
        {
            return mapper.Map<UserResponse>(await userRepository.GeUserByNameAsync(name));
        }

        public IList<string> GetUserRoles(int id)
        {
            var roles = new List<string>();

            foreach(var role in userRepository.GetUserRolesAsync(id))
            {
                roles.Add(role.Name);
            }

            return roles;
            
        }

        public async Task<bool> UpdateUser(UserUpdateRequest useraUpdateRequest)
        {
            var user = await userRepository.GetById(useraUpdateRequest.Id);
            if (user == null)
                return false;

            user.Name = useraUpdateRequest.Name;
            user.Email = useraUpdateRequest.Email;

            return await userRepository.Edit(user);
            
        }

        //public async Task<LocationResponse> GetUserLocation(int id)
        //{
        //    var location = await userRepository.GetUserLocation(id);
        //    if (location == null)
        //        return null;

        //    return new LocationResponse
        //    {
        //        Latitude = location.Latitude,
        //        Longitude = location.Longitude,
        //    };
        //}
    }
}
