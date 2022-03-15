using DeviceManagement.Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
        public string Location { get; set; }
        public ICollection<Device> Devices { get; set; }
    }

}
