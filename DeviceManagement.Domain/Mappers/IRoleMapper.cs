using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Role;

namespace DeviceManagement.Domain.Mappers
{
    public interface IRoleMapper
    {
        public RoleResponse MapToRoleResponse(Role role);
        public IEnumerable<RoleResponse> MapToRoleResponseList(List<Role> roles);
    }
}
