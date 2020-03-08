using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Entity.Common;

namespace TaskManagement.Entity.DomainModels
{
    public  class Ticket:BaseFieldsModel
    {
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
