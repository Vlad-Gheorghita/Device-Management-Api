using DeviceManagement.Domain.Models.User;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface IAccountService
    {
        Task<UserResponse> Register(UserRegisterRequest userCreateRequest);

        UserResponse Login(UserLoginRequest userLoginRequest);
    }
}
