using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Api.Models.Dtos;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.EntityContract;

namespace TaskManagement.Api.Controllers.V1
{
    [ApiVersion("1")]
    public class UserAccountController:GeneralBaseController
    {
        private readonly IJwtRpository _jwtRpository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserAccountController(IJwtRpository jwtRpository,IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            _jwtRpository = jwtRpository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> Token([FromBody]LoginDto login,CancellationToken cancellation)
        {
            var ValidUser = await _userRepository.LoginByMobile(login.MobileNumber, login.Password,cancellation);
            if (ValidUser)
            {
                var user = _unitOfWork.UserService.Table.Where(x => x.MobileNumber == login.MobileNumber).SingleOrDefault();
                var token =await _jwtRpository.GenerateTokenAsync(user);
                return new JsonResult(token);
            }
            return Unauthorized();
        }
    }
}
