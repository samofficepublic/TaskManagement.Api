using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.Contracts.EntityContract
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<bool> LoginByMobile(string MobileNumber,string Password,CancellationToken cancellationToken);
        Task<bool> LoginByEmail(string Email, string Password, CancellationToken cancellationToken);
    }
}