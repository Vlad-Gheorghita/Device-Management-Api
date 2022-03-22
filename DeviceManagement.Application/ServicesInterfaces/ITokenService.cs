using DeviceManagement.Domain.Entities;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
