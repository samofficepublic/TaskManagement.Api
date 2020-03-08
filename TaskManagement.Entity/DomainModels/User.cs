using System;
using TaskManagement.Entity.Common;

namespace TaskManagement.Entity.DomainModels
{
    public class User:BaseFieldsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool IsActive { get; set; }
    }
}