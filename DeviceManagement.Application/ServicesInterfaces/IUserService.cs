﻿using DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Application.ServicesInterfaces
{
    public interface IUserService
    {
        void Create(User user);
    }
}