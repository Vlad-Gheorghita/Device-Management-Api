﻿using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface IAccountService
    {
        Task<UserResponse> Register(UserRegisterRequest userCreateRequest);
        UserResponse Login(UserLoginRequest userLoginRequest);
    }
}
