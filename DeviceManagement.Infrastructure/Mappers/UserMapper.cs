

using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Mappers;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories;

namespace DeviceManagement.Infrastructure.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IRoleMapper roleMapper;

        public UserMapper(IRoleMapper roleMapper)
        {
            this.roleMapper = roleMapper;
        }

        public User MapFromRegisterRequest(UserRegisterRequest userRegisterRequest)
        {
            return new User
            {
                Name = userRegisterRequest.Name,
                Email = userRegisterRequest.Email,
                Password = userRegisterRequest.Password,
            };
        }

        public IEnumerable<UserResponse> MapToUser(IEnumerable<User> users)
        {
            return users.Select(user => this.MapToUserResponse(user));
        }

        public UserResponse MapToUserResponse(User user)
        {

            if (user == null)
                return null;

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                Roles = roleMapper.MapToRoleResponseList(user.Roles.ToList())
            };
        }
    }
}
