using DeviceManagement.Domain.Repositories.Generic;

namespace DeviceManagement.Domain.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
