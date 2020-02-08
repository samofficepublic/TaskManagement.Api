using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Data.Models;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.Contracts
{
    public interface IJwtRpository
    {
        Task<AccessToken> GenerateTokenAsync(User user);
    }
}
