using DeviceManagement.Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Entities
{
    public class Location : EntityBase
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
