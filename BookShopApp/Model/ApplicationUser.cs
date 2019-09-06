﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookShopApp.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
