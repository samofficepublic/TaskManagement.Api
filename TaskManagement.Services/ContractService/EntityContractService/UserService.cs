using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagement.Data;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Entity.DomainModels;
using TMS.Data.Services;

namespace TaskManagement.Services.ContractService.EntityContractService
{
    public class UserService:GenericRepository<User>,IUserRepository
    {
        public UserService(DbContext dbContext) : base(dbContext)
        {
        }
         
        public async Task<bool> LoginByMobile(string MobileNumber, string Password,CancellationToken cancellationToken)
        {
            var user = await Table.Where(x => x.MobileNumber == MobileNumber && x.Password == Password)
                .SingleOrDefaultAsync(cancellationToken);

            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> LoginByEmail(string Email, string Password, CancellationToken cancellationToken)
        {
            var user =await Table.Where(x => x.Email == Email && x.Password == Password)
                .SingleOrDefaultAsync(cancellationToken);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
