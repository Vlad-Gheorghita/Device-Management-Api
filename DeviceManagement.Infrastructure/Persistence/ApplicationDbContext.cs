using DeviceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Device> Devices { get; set; }
    }
}
