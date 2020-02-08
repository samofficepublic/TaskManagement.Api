using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data.Contracts;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GeneralBaseController:ControllerBase
    {
        public bool IsAuthenticate => HttpContext.User.Identity.IsAuthenticated;
    }
}
