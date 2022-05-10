using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories;
using AutoMapper;
using DeviceManagement.Domain.Mappers;

namespace DeviceManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IDeviceRepository deviceRepository;
        private readonly IMapper mapper;
        private readonly IUserMapper userMapper;

        public UserService(IUserRepository userRepository, IDeviceRepository deviceRepository, IMapper mapper, IUserMapper userMapper)
        {
            this.userRepository = userRepository;
            this.deviceRepository = deviceRepository;
            this.mapper = mapper;
            this.userMapper = userMapper;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            var devices = await deviceRepository.GetAllDevicesAsync();

            return await userRepository.Delete(user);
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {

            //return mapper.Map<IEnumerable<UserResponse>>(userRepository.GetAll());
            return this.userMapper.MapToUser(userRepository.GetAll());

        }

        public async Task<UserResponse> GetUserById(int id)
        {
            //return mapper.Map<UserResponse>(await userRepository.GetUserByIdAsync(id));
            return this.userMapper.MapToUserResponse(await userRepository.GetUserByIdAsync(id));
        }

        public async Task<UserResponse> GetUserByName(string name)
        {
            //return mapper.Map<UserResponse>(await userRepository.GeUserByNameAsync(name));
            return this.userMapper.MapToUserResponse(await userRepository.GeUserByNameAsync(name));
        }

        public IList<string> GetUserRoles(int id)
        {
            var roles = new List<string>();

            foreach (var role in userRepository.GetUserRolesAsync(id))
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

        public async Task<UserResponse> UpdateUserLocation(UserUpdateLocationRequest useraUpdateLocationRequest)
        {
            var user = await userRepository.GetUserByIdAsync(useraUpdateLocationRequest.id);
            if (user == null)
                return null;

            user.Latitude = useraUpdateLocationRequest.locationUpdateRequest.Latitude;
            user.Longitude = useraUpdateLocationRequest.locationUpdateRequest.Longitude;

            if (!(await userRepository.Edit(user)))
                return null;

            //return mapper.Map<UserResponse>(user);
            return this.userMapper.MapToUserResponse(user);
        }
    }
}
