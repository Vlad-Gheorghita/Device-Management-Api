using DeviceManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Models.Device
{
    public class DeviceCreateRequest
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DeviceType Type { get; set; }
        public string OperatingSystem { get; set; }
        public double OperatingSystemVersion { get; set; }
        public string Processor { get; set; }
        public long RAM { get; set; }
    }
}
