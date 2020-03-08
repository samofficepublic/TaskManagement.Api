using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Api.Models.Dtos
{
    public class EmailLoginDto
    {
        [EmailAddress(ErrorMessage = "ایمیل نامعتبر است")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
