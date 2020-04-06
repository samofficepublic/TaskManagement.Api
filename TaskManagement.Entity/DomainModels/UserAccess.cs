using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Entity.Common;

namespace TaskManagement.Entity.DomainModels
{
    public class UserAccess
    {
        public int Id { get; set; }
        public Int64 UserId { get; set; }
        public int AccessId { get; set; }

        public User User { get; set; }
        public Access Access { get; set; }
    }
}
