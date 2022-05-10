using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
namespace DeviceManagement.Domain.Mappers
{
    public interface IUserMapper
    {
        public User MapFromRegisterRequest(UserRegisterRequest userRegisterRequest);
        public UserResponse MapToUserResponse(User user);
        public IEnumerable<UserResponse> MapToUser(IEnumerable<User> users);

    }
}
