using AutoMapper;
using DeviceManagement.Application.Authorization;
using DeviceManagement.Application.ServicesInterfaces;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using DeviceManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        //private readonly IJwtUtils jwtUtils;

        public AccountService(IUserRepository userRepository, IMapper mapper)//, IJwtUtils jwtUtils)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            //this.jwtUtils = jwtUtils;
        }

        public async Task<UserResponse> Login(UserLoginRequest userLoginRequest)
        {
            var users = await userRepository.GetAllAsync();
            if (!users.Any(u => u.Email == userLoginRequest.Email))
                return null;

            var user = users.SingleOrDefault(u => u.Email == userLoginRequest.Email);

            if (!BCrypt.Net.BCrypt.Verify(userLoginRequest.Password, user.Password))
                return null;

            var userResponse = mapper.Map<UserResponse>(user);

            //var jwtToken = jwtUtils.GenerateJwtToken(userResponse);

            //userResponse.Token = jwtToken;

            return userResponse;



        }

        public async Task<UserResponse> Register(UserRegisterRequest userRegisterRequest)
        {
            var users = await userRepository.GetAllAsync();
            if (users.Any(u => u.Email == userRegisterRequest.Email || u.Name == userRegisterRequest.Name))
                return null;

            var user = mapper.Map<User>(userRegisterRequest);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRegisterRequest.Password);

            if (!(await userRepository.Add(user)))
                return null;

            return mapper.Map<UserResponse>(user);
        }
    }
}
