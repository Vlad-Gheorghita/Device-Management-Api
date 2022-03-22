using DeviceManagement.Domain.Models.Location;

namespace DeviceManagement.Domain.Models.User
{
    public class UserUpdateLocationRequest
    {
        public int id { get; set; }

        public LocationUpdateRequest locationUpdateRequest { get; set; }
    }
}
