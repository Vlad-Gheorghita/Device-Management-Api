using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Location;
using DeviceManagement.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Models.User
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public LocationResponse Location { get; set; }
        public string Token { get; set; }
        public ICollection<RoleResponse> Roles { get; set; }
        
    }
}
