using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Repositories.Generic;

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
