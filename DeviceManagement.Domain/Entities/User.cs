using DeviceManagement.Domain.Repositories.Generic;

namespace DeviceManagement.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Role> Roles { get; set; } = new List<Role>();

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public ICollection<Device> Devices { get; set; }
    }

}
