using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Repositories;
using DeviceManagement.Infrastructure.Data.Generic;
using DeviceManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public  IEnumerable<User> GetAll()
        {
            var users = dbContext.Users.Include(u => u.Roles).ToList();
            return users;

        }

        public User GetUserByEmail(string email)
        {
            return  dbContext.Users.Include(u => u.Roles).FirstOrDefault(x => x.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user =  await dbContext.Users.Include(u => u.Roles)
                       .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }


        public IEnumerable<Role> GetUserRolesAsync(int id)
        {
            var user = dbContext.Users.Include(u => u.Roles).SingleOrDefault(u => u.Id == id);

            return user.Roles.ToList();
        }

        public async Task<User> GeUserByNameAsync(string name)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
