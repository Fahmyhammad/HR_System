﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Domin.Entity
{
    public class VwUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool ActiveUser { get; set; }
        public string RoleName{ get; set; }
    }
}
