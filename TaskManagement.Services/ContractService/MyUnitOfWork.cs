using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Data;
using TaskManagement.Data.Contracts;
using TaskManagement.Entity.DomainModels;

namespace TMS.Data.Services
{
    public class MyUnitOfWork : IUnitOfWork
    {

        public MyAppContext DbContext { get ; set; }


        public MyUnitOfWork(MyAppContext myAppContext)
        {
            DbContext = myAppContext;
        }

        public bool Save()
        {
            try
            {
                DbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        {
            try
            {
                var saveResult = await DbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }

        }

        private bool disposed = false;



        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DisposeAsync(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void DisposeSync()
        {
            DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        #region Repositories
        public IGenericRepository<User> UserService =>new GenericRepository<User>(DbContext);
        public IGenericRepository<Ticket> TicketService =>new GenericRepository<Ticket>(DbContext);

        #endregion


    }
}
