﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Api.Models.Dtos
{
    public class MobileLoginDto
    {
        public string MobileNumber { get; set; }
        public string Password { get; set; }
    }
}
