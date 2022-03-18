using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;

namespace DeviceManagement.Application.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserResponse user);
        public int? ValidateJwtToken(string token);
    }
}
