using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Api.Models.Dtos;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Api.Controllers.V1
{
    [ApiVersion("1")]
    public class UserAccountController : GeneralBaseController
    {
        private readonly IJwtRpository _jwtRpository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        ILogger<UserAccountController> _logger;
        public UserAccountController(IJwtRpository jwtRpository, IUnitOfWork unitOfWork, IUserRepository userRepository, ILogger<UserAccountController> logger)
        {
            _jwtRpository = jwtRpository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> Token([FromBody]LoginDto login, CancellationToken cancellation)
        {

            if (login != null)
            {
                var user = new User()
                {
                    MobileNumber = login.MobileNumber,
                    Password = login.Password
                };
                var token = await _userRepository.LoginByMobile(user, cancellation);
                if (token == null)
                {
                    _logger.LogError("this my Error >>>>>>");
                    return Unauthorized();
                }
                
                return new JsonResult(token);
            }
            return Unauthorized();

        }
    }
}
