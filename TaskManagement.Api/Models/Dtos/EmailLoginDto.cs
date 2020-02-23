using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Api.Models.Dtos
{
    public class EmailLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
