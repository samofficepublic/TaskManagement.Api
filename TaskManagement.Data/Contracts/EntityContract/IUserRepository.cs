using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.Contracts.EntityContract
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<object> LoginByMobile(User user,CancellationToken cancellationToken);
        Task<object> LoginByEmail(User user, CancellationToken cancellationToken);
    }
}