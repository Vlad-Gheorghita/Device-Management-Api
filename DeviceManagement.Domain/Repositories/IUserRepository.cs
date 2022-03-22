using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public IEnumerable<User> GetAll();
        public Task<User> GeUserByNameAsync(string name);
        public Task<User> GetUserByIdAsync(int id);
        public User GetUserByEmail(string email);
        public IEnumerable<Role> GetUserRolesAsync(int id);
    }
}
