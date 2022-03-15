using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Models.User
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
