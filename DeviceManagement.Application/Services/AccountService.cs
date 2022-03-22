using AutoMapper;
using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories;

namespace DeviceManagement.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;
        private readonly IRoleRepository roleRepository;

        public AccountService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.roleRepository = roleRepository;
        }

        public UserResponse Login(UserLoginRequest userLoginRequest)
        {
            var user = userRepository.GetUserByEmail(userLoginRequest.Email);
            if (user == null)
                return null;


            if (!BCrypt.Net.BCrypt.Verify(userLoginRequest.Password, user.Password))
                return null;

            var userResponse = mapper.Map<UserResponse>(user);

            userResponse.Token = this.tokenService.CreateToken(user);

            return userResponse;
        }

        public async Task<UserResponse> Register(UserRegisterRequest userRegisterRequest)
        {
            var users = userRepository.GetAll();
            if (users.Any(u => u.Email == userRegisterRequest.Email || u.Name == userRegisterRequest.Name))
                return null;

            var user = mapper.Map<User>(userRegisterRequest);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRegisterRequest.Password);
            user.Roles.Add(await roleRepository.GetById(2)); //Add as member

            if (!(await userRepository.Add(user)))
                return null;

            var userResponse = mapper.Map<UserResponse>(user);
            userResponse.Token = this.tokenService.CreateToken(user);

            return userResponse;
        }
    }
}
