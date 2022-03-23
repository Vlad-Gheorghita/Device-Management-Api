using DeviceManagement.Domain.Enums;
using DeviceManagement.Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement.Domain.Entities
{
    public class Device : EntityBase
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public DeviceType Type { get; set; }

        public string OperatingSystem { get; set; }

        public string OperatingSystemVersion   { get; set; }

        public string Processor { get; set; }

        public long RAM { get; set; }

        public User User { get; set; }
    }
}
