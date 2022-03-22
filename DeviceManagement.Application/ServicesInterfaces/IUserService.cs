using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Location;
using DeviceManagement.Domain.Models.User;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface IUserService
    {

        public IEnumerable<UserResponse> GetAllUsers();

        public Task<UserResponse> GetUserById(int id);

        public Task<bool> UpdateUser(UserUpdateRequest useraUpdateRequest);

        public Task<UserResponse> GetUserByName(string name);

        public Task<bool> DeleteUser(int id);

        public IList<string> GetUserRoles(int id);

        //public Task<LocationResponse> GetUserLocation(int id);

    }
}
