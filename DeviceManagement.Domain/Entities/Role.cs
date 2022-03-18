﻿using DeviceManagement.Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
