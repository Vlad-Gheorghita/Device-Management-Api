using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Repositories;
using DeviceManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
