using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Contracts;
using TaskManagement.Data.Contracts.BaseInfoInitialize;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Services.ContractService.BaseInfoInitializeService
{
    public class AccessDataSeedingService : DataSeedingRepository
    {
        private IUnitOfWork _uow;

        public AccessDataSeedingService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public override async Task InitializeData(CancellationToken cancellationToken)
        {
            try
            {
                if (_uow == null)
                {
                    throw  new Exception("Injected Class is null");
                }
                var accessList = GenerateAccessList();
                
                var accessOnDb = await _uow.AccessService.TableNoTracking.ToListAsync();
                if (accessOnDb.Any())
                {
                    if (accessList.Count != accessOnDb.Count)
                    {
                        var differenceAccess = accessList.Where(x => !accessOnDb.Contains(x));
                        await _uow.AccessService.AddRangeAsync(differenceAccess, cancellationToken);
                    }
                }
                else
                {
                    await _uow.AccessService.AddRangeAsync(accessList, cancellationToken);
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message, exception);
            }

        }

        private static List<Access> GenerateAccessList()
        {
            List<Access> accessList = new List<Access>
            {
                new Access
                {
                    Id = 1,
                    AccessComponent = "Tickets",
                    AccessRoute = "/Tickets",
                    AccessName = "لیست تیکتها"
                }
            };
            return accessList;
        }
    }
}
