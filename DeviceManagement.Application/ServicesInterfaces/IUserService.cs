using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  
    }
}
