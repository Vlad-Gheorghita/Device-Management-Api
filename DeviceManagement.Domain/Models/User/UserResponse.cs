using DeviceManagement.Domain.Models.Role;

namespace DeviceManagement.Domain.Models.User
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Token { get; set; }

        public IEnumerable<RoleResponse> Roles { get; set; }
        
    }
}
