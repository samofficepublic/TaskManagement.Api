using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using TaskManagement.Data;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Entity.DomainModels;
using TMS.Data.Services;

namespace TaskManagement.Services.ContractService.EntityContractService
{
    public class UserService : GenericRepository<User>, IUserRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IJwtRpository jwtRpository;
        private ILogger<UserService> logger;
        public UserService(MyAppContext dbContext, IUnitOfWork unitOfWork, IJwtRpository jwtRpository,ILogger<UserService> logger) : base(dbContext)
        {
            this.unitOfWork = unitOfWork;
            this.jwtRpository = jwtRpository;
            this.logger = logger;
        }

        public async Task<object> LoginByMobile(User user, CancellationToken cancellationToken)
        {
            try
            {
                if (user==null)
                {
                    throw new Exception("User Is Null");
                }
                var userResult = await unitOfWork.UserService.Table.Where(x => x.MobileNumber == user.MobileNumber && x.Password == user.Password).SingleOrDefaultAsync(cancellationToken);

                if (userResult != null)
                {

                    var token = await jwtRpository.GenerateTokenAsync(userResult);

                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch ( Exception e)
            {
                logger.LogInformation(e.Message);
                return null;
            }

        }

        public async Task<object> LoginByEmail(User user, CancellationToken cancellationToken)
        {
            var userResult = await Table.Where(x => x.Email == user.Email && x.Password == user.Password)
                .SingleOrDefaultAsync(cancellationToken);
            if (user != null)
            {
                var token = await jwtRpository.GenerateTokenAsync(user);


                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
