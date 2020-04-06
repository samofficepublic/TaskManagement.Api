using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Data.Contracts.EntityContract;
using TaskManagement.Entity.DomainModels;
using TMS.Data.Services;

namespace TaskManagement.Services.ContractService.EntityContractService
{
    public class AccessService:GenericRepository<Access>,IAccessRepository
    {
        public AccessService(MyAppContext dbContext) : base(dbContext)
        {
        }
    }
}
