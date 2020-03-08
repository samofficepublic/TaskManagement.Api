using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Api.Models.Dtos
{
    public class PaginationDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
