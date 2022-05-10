

using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Mappers;
using DeviceManagement.Domain.Models.Role;

namespace DeviceManagement.Infrastructure.Mappers
{
    public class RoleMapper : IRoleMapper
    {
        public RoleResponse MapToRoleResponse(Role role)
        {
            return new RoleResponse
            {
                Name = role.Name
            };
        }

        public IEnumerable<RoleResponse> MapToRoleResponseList(List<Role> roles)
        {
            return roles.Select(role =>
                new RoleResponse { Name = role.Name }
            ).ToList();

        }
    }
}
