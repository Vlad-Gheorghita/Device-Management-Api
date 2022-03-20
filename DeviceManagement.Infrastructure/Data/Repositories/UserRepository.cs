using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories;
using DeviceManagement.Infrastructure.Data.Generic;
using DeviceManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await dbContext.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);
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
