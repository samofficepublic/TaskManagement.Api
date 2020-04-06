using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement.Data.Contracts.BaseInfoInitialize
{
    public abstract class DataSeedingRepository
    {
        public abstract Task InitializeData(CancellationToken cancellationToken);
    }
}
