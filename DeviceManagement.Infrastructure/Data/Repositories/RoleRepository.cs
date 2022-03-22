using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Repositories;
using DeviceManagement.Infrastructure.Data.Generic;
using DeviceManagement.Infrastructure.Persistence;

namespace DeviceManagement.Infrastructure.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
