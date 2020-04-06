using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.Contracts
{
    public interface IUnitOfWork
    {
        bool Save();
        Task<bool> SaveAsync(CancellationToken cancellationToken);
        void Dispose(bool disposing);
        void DisposeAsync(bool disposing);



        #region Contracts

        IGenericRepository<User> UserService { get; }
        IGenericRepository<Ticket> TicketService { get; }
        IGenericRepository<Access> AccessService { get; }
        IGenericRepository<UserAccess> UserAccessService { get; }

        #endregion
    }
}
