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
    public class SeedDataService : ISeedDataRepository
    {
        public async Task InitializeData(IUnitOfWork _uow, CancellationToken cancellationToken)
        {
            await AccessSeedData(_uow, cancellationToken);
        }

        private static async Task AccessSeedData(IUnitOfWork _uow, CancellationToken cancellationToken)
        {
            try
            {
                if (_uow == null)
                {
                    throw new Exception("Injected Class is null");
                }

                var accessList = new List<Access>
                {
                    new Access
                    {
                        AccessComponent = "Tickets",
                        AccessRoute = "/Tickets",
                        AccessName = "لیست تیکتها"
                    }
                };


                var accessOnDb = await _uow.AccessService.TableNoTracking.ToListAsync();
                if (accessOnDb.Any())
                {
                    if (accessList.Count != accessOnDb.Count)
                    {
                        var differenceAccess =
                            accessList.Select(x => 
                                new
                                {
                                    x.AccessName, x.AccessComponent, x.AccessRoute
                                })
                                .Except(accessOnDb.Select(x =>
                                    new
                                    {
                                        x.AccessName, x.AccessComponent, x.AccessRoute
                                    }))
                                .ToList();

                        accessList=new List<Access>();

                        foreach (var item in differenceAccess)
                        {
                            var newItem=new Access()
                            {
                                AccessName = item.AccessName,
                                AccessComponent = item.AccessComponent,
                                AccessRoute = item.AccessRoute
                            };
                            accessList.Add(newItem);
                        }
                        
                        await _uow.AccessService.AddRangeAsync(accessList, cancellationToken);
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
    }
}
