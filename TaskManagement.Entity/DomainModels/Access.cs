using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace TaskManagement.Entity.DomainModels
{
    public class Access
    {
        public int Id { get; set; }
        public string AccessName { get; set; }
        public string AccessRoute { get; set; }
        public string AccessComponent { get; set; }

        public virtual ICollection<UserAccess> Accesses { get; set; }
    }
}
