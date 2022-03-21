using AutoMapper;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.Device;
using DeviceManagement.Domain.Models.Role;
using DeviceManagement.Domain.Models.User;

namespace DeviceManagement.WebApi
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRegisterRequest, User>();
            CreateMap<Device, DeviceResponse>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<DeviceCreateRequest, Device>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<Role, RoleResponse>();
        }
    }
}
