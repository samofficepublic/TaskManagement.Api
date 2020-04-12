using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement.Data.Contracts.BaseInfoInitialize
{
    public interface ISeedDataRepository
    {
        public Task InitializeData(IUnitOfWork unitOfWork,CancellationToken cancellationToken);
    }
}
