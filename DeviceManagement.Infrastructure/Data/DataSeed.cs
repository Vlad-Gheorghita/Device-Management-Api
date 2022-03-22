using DeviceManagement.Domain.Entities;
using DeviceManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Infrastructure.Data
{
    public class DataSeed
    {
        public static async Task Seed(ApplicationDbContext dbContext)
        {
            if (await dbContext.Users.AnyAsync()) return;

            if(await dbContext.Roles.AnyAsync()) return;

            await dbContext.Roles.AddAsync(new Role { Name = "Admin" });

            await dbContext.Roles.AddAsync(new Role { Name = "Member" });

            await dbContext.SaveChangesAsync();
        }
    }
}
