using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TaskManagement.Data.Contracts;

namespace TaskManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GeneralBaseController:ControllerBase
    {
        public bool IsAuthenticate => HttpContext.User.Identity.IsAuthenticated;

        protected Int64 GetUserIDOfClaim()
        {
            return Int64.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value.ToString());
        }

        protected string GetEmailOfClaim()
        {
            return User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
        }

        protected string GetMobileOfClaim()
        {
            return User.Claims.First(x => x.Type == ClaimTypes.MobilePhone).Value;
        }

        protected string GetNameOfClaim()
        {
            return User.Claims.First(x => x.Type == ClaimTypes.Name).Value;

        }
    }
}
