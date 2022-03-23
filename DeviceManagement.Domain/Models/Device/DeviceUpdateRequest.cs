using DeviceManagement.Domain.Enums;

namespace DeviceManagement.Domain.Models.Device
{
    public class DeviceUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public DeviceType Type { get; set; }

        public string OperatingSystem { get; set; }

        public string OperatingSystemVersion { get; set; }

        public string Processor { get; set; }

        public long RAM { get; set; }
    }
}
